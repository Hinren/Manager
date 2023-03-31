using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibs.Utilities
{
    public static class ObjectUtilities
    {

        //  METHODS

        #region PROPERTIES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get public properties from class object. </summary>
        /// <typeparam name="T"> Class object type. </typeparam>
        /// <param name="obj"> Class object. </param>
        /// <returns> Array of class properties. </returns>
        public static PropertyInfo[] GetObjectProperties<T>(T obj, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public) where T : class
        {
            return obj.GetType().GetProperties(flags);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get public properties from class type. </summary>
        /// <param name="type"> Class type. </param>
        /// <returns> Array of class properties. </returns>
        public static PropertyInfo[] GetObjectProperties(Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
        {
            return type.GetProperties(flags);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get class object property value. </summary>
        /// <typeparam name="T"> Class object type. </typeparam>
        /// <param name="obj"> Class object. </param>
        /// <param name="propertyName"> Property name (case matters). </param>
        /// <returns> Class object property value or null. </returns>
        public static object? GetPropertyValue<T>(T obj, string propertyName)
        {
            var type = obj?.GetType();

            if (type != null && type.GetProperty(propertyName) is PropertyInfo propertyInfo)
                return propertyInfo.GetValue(obj);

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if class object contains property. </summary>
        /// <typeparam name="T"> Class object type. </typeparam>
        /// <param name="obj"> Class object. </param>
        /// <param name="propertyName"> Property name (case matters). </param>
        /// <returns> True - class object type contains property; False - otherwise. </returns>
        public static bool HasProperty<T>(T obj, string propertyName)
        {
            return obj?.GetType()?.GetProperty(propertyName) != null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if class object contains property. </summary>
        /// <param name="type"> Class type. </param>
        /// <param name="propertyName"> Property name (case matters). </param>
        /// <returns> True - type contains property; False - otherwise. </returns>
        public static bool HasProperty(Type type, string propertyName)
        {
            return type?.GetProperty(propertyName) != null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set class object property value. </summary>
        /// <typeparam name="T"> Class object type. </typeparam>
        /// <param name="obj"> Class object. </param>
        /// <param name="propertyName"> Property name (case matters). </param>
        /// <param name="value"> New value. </param>
        /// <returns> True - value set; False - otherwise. </returns>
        public static bool SetPropertyValue<T>(T obj, string propertyName, object value)
        {
            var type = obj?.GetType();

            if (type != null && type.GetProperty(propertyName) is PropertyInfo propertyInfo)
            {
                propertyInfo.SetValue(obj, value);
                return true;
            }

            return false;
        }

        #endregion PROPERTIES METHODS

    }
}
