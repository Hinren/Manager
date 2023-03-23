using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ProjectManager.Utilities
{
    public class DispatcherHandler
    {

        //  VARIABLES

        private Exception _lastRunException;

        public Dispatcher Dispatcher { get; set; }
        public bool LastRunResult { get; private set; }


        //  GETTERS & SETTERS

        public Exception LastRunException
        {
            get
            {
                var exception = _lastRunException;
                _lastRunException = null;
                return exception;
            }
        }


        //  METHODS

        #region CLASS CONSTRUCTOR

        //  --------------------------------------------------------------------------------
        /// <summary> DispatcherHandler class constructor. </summary>
        /// <param name="dispatcher"> Dispatcher. </param>
        public DispatcherHandler(Dispatcher dispatcher)
        {
            Dispatcher = dispatcher;
            LastRunResult = false;
        }

        #endregion CLASS CONSTRUCTOR

        #region INVOKING METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Try invoke an action by dispatcher. </summary>
        /// <param name="callback"> Action to invoke. </param>
        /// <returns> True - action completed successfully; False - otherwise. </returns>
        public bool TryInvoke(Action callback)
        {
            if (Dispatcher == null || callback == null)
            {
                LastRunResult = false;
                return LastRunResult;
            }

            try
            {
                Dispatcher?.Invoke(() =>
                {
                    try
                    {
                        callback?.Invoke();
                        LastRunResult = true;
                    }
                    catch (Exception innerExc)
                    {
                        _lastRunException = innerExc;
                        LastRunResult = false;
                    }
                });
            }
            catch (Exception outerExc)
            {
                _lastRunException = outerExc;
                LastRunResult = false;
            }

            return LastRunResult;
        }

        #endregion INVOKING METHODS

    }
}
