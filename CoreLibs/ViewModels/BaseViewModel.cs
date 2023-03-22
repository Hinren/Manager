using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibs.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseViewModel class constructor. </summary>
        public BaseViewModel() { }

        #endregion CLASS METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

    }
}
