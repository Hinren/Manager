using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Hinren.ProjectManager.Utilities
{
    public static class ApplicationHelper
    {

        //  METHODS

        #region INFORMATION GETTERS

        //  --------------------------------------------------------------------------------
        /// <summary> Get application assembly name. </summary>
        /// <returns> Application assembly name. </returns>
        public static string GetApplicationName()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName();
            return assemblyName?.Name;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get application assembly company. </summary>
        /// <returns> Application assembly company. </returns>
        public static string GetApplicationCompany()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var attributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), true);

            if (attributes.Length > 0)
                return ((AssemblyCompanyAttribute)attributes.FirstOrDefault())?.Company;

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get application assembly copyright. </summary>
        /// <returns> Application assembly copyright. </returns>
        public static string GetApplicationCopyright()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true);

            if (attributes.Length > 0)
                return ((AssemblyCopyrightAttribute)attributes.FirstOrDefault())?.Copyright;

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get application executable file location path. </summary>
        /// <returns> Application executable file location path. </returns>
        public static string GetApplicationLocation()
        {
            return Assembly.GetEntryAssembly().Location;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get application executable file directory path. </summary>
        /// <returns> Application executable file location path. </returns>
        public static string GetApplicationPath()
        {
            return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get application assembly title. </summary>
        /// <returns> Application assembly title. </returns>
        public static string GetApplicationTitle()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), true);

            if (attributes.Length > 0)
                return ((AssemblyTitleAttribute)attributes.FirstOrDefault())?.Title;

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get application verion. </summary>
        /// <returns> Application version. </returns>
        public static Version GetApplicationVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName();

            return assemblyName?.Version;
        }

        #endregion INFORMATION GETTERS

    }
}
