using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ProjectManager.Utilities
{
    public class ApplicationInstanceCommunicator : IDisposable
    {

        //  EVENTS

        public EventHandler<string> DataReceived;


        //  VARIABLES

        private string _applicationName;
        private BackgroundWorker _listener;


        //  GETTERS & SETTERS

        public bool IsListening
        {
            get => _listener != null && _listener.IsBusy;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ApplicationInstanceCommunicator class constructor. </summary>
        /// <param name="applicationName"> Application name identifier. </param>
        public ApplicationInstanceCommunicator(string applicationName)
        {
            _applicationName = applicationName;
            CreateListener();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Perform application-defined task associated with freeing, releasing, 
        /// or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            if (_listener != null && _listener.IsBusy)
            {
                _listener.CancelAsync();
            }
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Stop listening. </summary>
        public void StopListening()
        {
            if (_listener != null && _listener.IsBusy)
                _listener.CancelAsync();
        }

        #endregion INTERACTION METHODS

        #region LISTENER MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create listener. </summary>
        private void CreateListener()
        {
            if (_listener == null || !_listener.IsBusy)
            {
                _listener = new BackgroundWorker();
                _listener.DoWork += OnListening;
                _listener.RunWorkerCompleted += OnListeningFinished;
                _listener.WorkerSupportsCancellation = true;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Listening and reading data from another application instances. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Do Work Event Arguments. </param>
        private void OnListening(object sender, DoWorkEventArgs e)
        {
            using (var server = new NamedPipeServerStream(_applicationName))
            {
                using (var reader = new StreamReader(server))
                {
                    while (!e.Cancel)
                    {
                        server.WaitForConnection();
                        var data = reader.ReadToEnd();
                        server.Disconnect();

                        if (!string.IsNullOrEmpty(data))
                            DataReceived?.Invoke(this, data);
                    }
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after listening finished. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Run Worker Completed Event Arguments. </param>
        private void OnListeningFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            CreateListener();
        }

        #endregion LISTENER MANAGEMENT METHODS

        #region STATIC METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Send message to another application instance. </summary>
        /// <param name="applicationName"> Application name identifier. </param>
        /// <param name="data"> Data to send. </param>
        public static void SendMessage(string applicationName, string data)
        {
            using (var client = new NamedPipeClientStream(applicationName))
            {
                client.Connect();

                using (var writer = new StreamWriter(client))
                {
                    writer.WriteLine(data);
                    writer.Close();
                }

                client.Close();
            }
        }

        #endregion STATIC METHODS

    }
}
