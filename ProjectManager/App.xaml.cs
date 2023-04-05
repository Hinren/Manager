using chkam05.Tools.ControlsEx.InternalMessages;
using ProjectManager.Data.Configuration;
using ProjectManager.Utilities;
using ProjectManager.Windows;
using System.Threading;
using System.Windows;


namespace ProjectManager
{
    public partial class App : Application
    {

        //  VARIABLES

        private static Mutex _instancesLimiter = null;

        public ConfigManager ConfigurationManager { get; private set; }
        public ApplicationInstanceCommunicator InstancesListener { get; private set; }


        //  METHODS

        #region APPLICATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after starting up application. </summary>
        /// <param name="e"> Startup Event Arguments. </param>
        protected override void OnStartup(StartupEventArgs e)
        {
            string appName = ApplicationHelper.GetApplicationName();
            bool isNewInstance;

            _instancesLimiter = new Mutex(true, appName, out isNewInstance);

            if (!isNewInstance)
            {
                ApplicationInstanceCommunicator.SendMessage(appName, string.Join("|", e.Args));
                MessageBox.Show("Application is already running.", appName, MessageBoxButton.OK, MessageBoxImage.Error);
                Current.Shutdown();
                return;
            }
            else
            {
                ConfigurationManager = ConfigManager.Instance;
                InstancesListener = new ApplicationInstanceCommunicator(appName);
            }

            base.OnStartup(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked during application close. </summary>
        /// <param name="e"> Exit Event Arguments. </param>
        protected override void OnExit(ExitEventArgs e)
        {
            if (InstancesListener != null)
                InstancesListener.Dispose();

            _instancesLimiter?.ReleaseMutex();
            _instancesLimiter?.Dispose();

            base.OnExit(e);
        }

        #endregion APPLICATION METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get internal messages ex container from main window. </summary>
        /// <returns> Internal messages ex container. </returns>
        public static InternalMessagesExContainer GetIMContainer()
        {
            return ((MainWindow)((App)Application.Current).MainWindow).InternalMessagesContainer;
        }

        #endregion UTILITY METHODS

    }
}
