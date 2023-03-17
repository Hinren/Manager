using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectManager.Data.Dashboard
{
    public class DashboardComponentPosition
    {

        //  VARIABLES

        [JsonIgnore]
        public FrameworkElement FrameworkElement { get; set; }
        public string Name { get; set; }
        public int ColumnIndex { get; set; }
        public int Position { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DashboardComponentPosition class constructor. </summary>
        public DashboardComponentPosition()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> DashboardComponentPosition class constructor. </summary>
        public DashboardComponentPosition(FrameworkElement frameworkElement, int columnIndex, int position)
        {
            FrameworkElement = frameworkElement;
            Name = frameworkElement.Name;
            ColumnIndex = columnIndex;
            Position = position;
        }

        #endregion CLASS METHODS

    }
}
