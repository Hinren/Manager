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
        public DashboardConfig()
        {
            //
        }

        #endregion CLASS METHODS

    }
}
