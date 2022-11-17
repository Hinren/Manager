using DomainModel.Models.SettingsUserApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hinren.ProjectManager.Data.Settings
{
    public class Configuration
    {

        //  VARIABLES

        public Converting ConvertingSettings { get; set; }
        public UIConfiguration UIConfiguration { get; set; }

        public string UserName { get; set; }

    }
}
