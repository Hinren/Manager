using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Utilities
{
    public static class ObjectHelper
    {

        //  METHODS

        #region ATTRIBUTES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if property contains attribute. </summary>
        /// <param name="property"> Property info, </param>
        /// <param name="attributeType"> Attribute type. </param>
        /// <returns> True - property contains attribute; False - otherwise. </returns>
        public static bool HasAttribute(PropertyInfo property, Type attributeType)
        {
            return Attribute.IsDefined(property, attributeType);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of attributes with specified type. </summary>
        /// <typeparam name="T"> Attribute type. </typeparam>
        /// <param name="property"> Property info, </param>
        /// <returns> List of attributes or empty array. </returns>
        public static List<T> GetAttribute<T>(PropertyInfo property) where T : Attribute
        {
            if (HasAttribute(property, typeof(T)))
            {
                var attributes = (T[])property.GetCustomAttributes(typeof(T), false);

                if (attributes != null && attributes.Any())
                    return attributes.ToList();
            }

            return new List<T>();
        }

        #endregion ATTRIBUTES METHODS

        #region ENUM METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of enum values. </summary>
        /// <typeparam name="T"> Enum type. </typeparam>
        /// <returns> List of enum values. </returns>
        public static List<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        #endregion ENUM METHODS

        #region PROPERTIES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get public valuable properties from class object. </summary>
        /// <typeparam name="T"> Class object type. </typeparam>
        /// <param name="obj"> Class object. </param>
        /// <returns> Array of class properties. </returns>
        public static PropertyInfo[] GetObjectProperties<T>(T obj) where T : class
        {
            return obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get public valuable properties from class type. </summary>
        /// <param name="type"> Class type. </param>
        /// <returns> Array of class properties. </returns>
        public static PropertyInfo[] GetObjectProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        }

        #endregion PROPERTIES METHODS

        #region TYPES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if type has specified name. </summary>
        /// <param name="type"> Type. </param>
        /// <param name="typeName"> Type name to check. </param>
        /// <param name="isFullName"> True - check by full name; False - check by short name. </param>
        /// <returns> True - type has speicifeid name; False - otherwise. </returns>
        public static bool CheckTypeByName(Type type, string typeName, bool isFullName = false)
        {
            if (type != null && !string.IsNullOrEmpty(typeName))
                return isFullName ? type.FullName == typeName : type.Name == typeName;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if array of types contains type with specified name. </summary>
        /// <param name="types"> Array of types. </param>
        /// <param name="typeName"> Type name to check. </param>
        /// <param name="isFullName"> True - check by full name; False - check by short name. </param>
        /// <returns> Found type. </returns>
        public static Type CheckTypesByName(Type[] types, string typeName, bool isFullName = false)
        {
            if (types != null && types.Any() && !string.IsNullOrEmpty(typeName))
            {
                var foundType = types.FirstOrDefault(
                    t => isFullName ? t.FullName == typeName : t.Name == typeName);

                return foundType != null ? foundType : null;
            }

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get assingable class types from interface. </summary>
        /// <typeparam name="T"> Interface type. </typeparam>
        /// <returns> Array of classes assingable from interface. </returns>
        public static Type[] GetAssingableFrom<T>()
        {
            if (!typeof(T).IsInterface)
                return null;

            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(T).IsAssignableFrom(p) && p.IsClass)
                .ToArray();
        }

        #endregion TYPES METHODS

    }
}
