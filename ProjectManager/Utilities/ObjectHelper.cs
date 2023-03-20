using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;
using System.Windows.Controls;

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

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Find child component by its name. </summary>
        /// <typeparam name="T"> Component type. </typeparam>
        /// <param name="parent"> Parent component (usually first). </param>
        /// <param name="childName"> Component name. </param>
        /// <returns> Found component or null. </returns>
        public static T FindChildComponentByName<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            if (parent == null)
                return null;

            if (parent is FrameworkElement frameworkElement && frameworkElement.Name == childName)
                return parent as T;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                T result = FindChildComponentByName<T>(child, childName);

                if (result != null)
                    return result;
            }

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Find parent component by its type. </summary>
        /// <typeparam name="T"> Parent component type. </typeparam>
        /// <param name="child"> Child component. </param>
        /// <returns> Found parent component or null. </returns>
        public static T FindParentComponent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);

            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as T;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get position of component in StackPanel or WrapPanel. </summary>
        /// <param name="element"> Component which position should be obtained. </param>
        /// <returns> Component position index. </returns>
        public static int GetComponentPositionInPanel(FrameworkElement element)
        {
            if (element == null)
                return -1;

            Panel parent = VisualTreeHelper.GetParent(element) as Panel;

            if (parent == null)
                return -1;

            if (parent is StackPanel stackPanel)
            {
                return stackPanel.Children.IndexOf(element);
            }
            else if (parent is WrapPanel wrapPanel)
            {
                return wrapPanel.Children.IndexOf(element);
            }

            return -1;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get all children components in parent component. </summary>
        /// <param name="parent"> Parent component. </param>
        /// <returns> List of all children components of parent components. </returns>
        public static List<FrameworkElement> GetChildComponents(DependencyObject parent)
        {
            var children = new List<FrameworkElement>();

            if (parent == null)
                return children;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                if (child is FrameworkElement frameworkElement)
                    children.Add(frameworkElement);
            }

            return children;
        }

        #endregion COMPONENT METHODS

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
