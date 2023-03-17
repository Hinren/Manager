using Newtonsoft.Json;
using ProjectManager.Data.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Configuration
{
    public class DashboardConfig
    {

        //  VARIABLES

        public List<DashboardComponentPosition> ComponentsPosition;
        public bool RecentlyUsedItemsEnabled { get; set; } = true;
        public bool RecentlyUsedItemsExtended { get; set; } = true;
        public bool TipsAndTricksTabEnabled { get; set; } = true;
        public bool TipsAndTricksTabExtended { get; set; } = true;
        public bool WelcomeTabEnabled { get; set; } = true;
        public bool WelcomeTabExtended { get; set; } = true;


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DashboardConfig class constructor. </summary>
        [JsonConstructor]
        public DashboardConfig(List<DashboardComponentPosition> componentsPosition = null)
        {
            ComponentsPosition = componentsPosition ?? new List<DashboardComponentPosition>();
        }

        #endregion CLASS METHODS

    }
}
