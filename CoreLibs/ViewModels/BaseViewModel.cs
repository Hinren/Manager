using CoreLibs.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibs.ViewModels
{
    [Serializable]
    public class BaseViewModel : INotifyPropertyChanged, ICloneable
    {

        //  EVENTS

        [NonSerialized]
        PropertyChangedEventHandler _propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { _propertyChanged += value; }
            remove { _propertyChanged -= value; }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseViewModel class constructor. </summary>
        public BaseViewModel() { }

        #endregion CLASS METHODS

        #region CLONE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Make object copy. </summary>
        /// <returns> Object copy. </returns>
        public virtual object Clone()
        {
            return new BaseViewModel();
        }

        #endregion CLONE METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = _propertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update values with values from other object instance. </summary>
        /// <param name="model"> BaseViewModel object instance. </param>
        public virtual void UpdateValues(BaseViewModel model)
        {
            if (model.GetType() != this.GetType())
                return;

            foreach (var property in ObjectUtilities.GetObjectProperties(this))
            {
                var currentObj = ObjectUtilities.GetPropertyValue(this, property.Name);
                var modelObj = ObjectUtilities.GetPropertyValue(model, property.Name);

                if (modelObj is BaseViewModel baseViewModel)
                {
                    if (currentObj is BaseViewModel currentBaseViewModel)
                        currentBaseViewModel.UpdateValues(baseViewModel);
                    else
                        ObjectUtilities.SetPropertyValue(this, property.Name, baseViewModel.Clone());
                }
                else if (modelObj != null)
                {
                    ObjectUtilities.SetPropertyValue(this, property.Name, modelObj);
                }
                else if (currentObj != null)
                {
                    ObjectUtilities.SetPropertyValue(this, property.Name, null);
                }
            }
        }

        #endregion UPDATE METHODS

    }
}
