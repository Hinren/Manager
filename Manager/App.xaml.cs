using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Manager
{
    public partial class App : Application
    {

        #region APPLICATION INFORMATIONS

        public string GetApplicationName()
        {
            return Assembly.GetExecutingAssembly()?.GetName()?.Name;
        }

        public string GetApplicationCompany()
        {
            var attributes = Assembly.GetExecutingAssembly()?
                .GetCustomAttributes(typeof(AssemblyCompanyAttribute), true);

            return attributes != null && attributes.Length > 0
                ? ((AssemblyCompanyAttribute)attributes.FirstOrDefault())?.Company
                : null;
        }

        public string GetApplicationCopyright()
        {
            var attributes = Assembly.GetExecutingAssembly()?
                .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true);

            return attributes != null && attributes.Length > 0
                ? ((AssemblyCopyrightAttribute)attributes.FirstOrDefault())?.Copyright
                : null;
        }

        public string GetApplicationLocation()
        {
            return Assembly.GetEntryAssembly().Location;
        }

        public string GetApplicationPath()
        {
            return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }

        public string GetApplicationTitle()
        {
            var attributes = Assembly.GetExecutingAssembly()?
                .GetCustomAttributes(typeof(AssemblyTitleAttribute), true);

            return attributes != null && attributes.Length > 0
                ? ((AssemblyTitleAttribute)attributes.FirstOrDefault())?.Title
                : null;
        }

        public Version GetApplicationVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch (Exception)
            {
                return Assembly.GetExecutingAssembly()?.GetName()?.Version;
            }
        }

        #endregion APPLICATION INFORMATIONS

    }
}
