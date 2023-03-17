using chkam05.Tools.ControlsEx;
using ProjectManager.Data.Configuration;
using ProjectManager.Data.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ProjectManager.Utilities
{
    public class DashboardUIHelper
    {

        //  CONST

        private const int COLUMN_MIN_WIDTH = 384;
        private const int MAX_COLUMNS = 3;


        //  VARIABLES

        private Grid _dashboardGrid;
        private List<DashboardComponentPosition> _dashboardComponents;
        private Dictionary<int, StackPanel> _dashboardContainers;

        private int _columnsAmount = 2;
        private bool _isInitialized = false;


        //  GETTERS & SETTERS

        public List<DashboardComponentPosition> DashboardComponents
        {
            get => _dashboardComponents;
        }

        public bool IsInitialized
        {
            get => _isInitialized;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DashboardUIHelper constructor. </summary>
        public DashboardUIHelper()
        {
            
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Initialize dashboard UI helper. </summary>
        /// <param name="dashboardGrid"> Dashboard grid. </param>
        /// <param name="dashboardConfiguration"> Dashboard configuration data. </param>
        public void InitializeHelper(Grid dashboardGrid, DashboardConfig dashboardConfiguration)
        {
            _dashboardGrid = dashboardGrid;

            LoadDashboardContainers();
            LoadComponentsPositions(dashboardConfiguration);
            UpdateDashboardComponentsPosition();

            _isInitialized = true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Move dashboard component from one container to another. </summary>
        /// <param name="sourceContainer"> Source dashboard container. </param>
        /// <param name="targetContainer"> Target dashboard container. </param>
        /// <param name="component"> Dashboard component to move. </param>
        /// <param name="e"> Drag Event Args. </param>
        public void MoveDashboardComponent(StackPanel sourceContainer, StackPanel targetContainer, FrameworkElement component, DragEventArgs e)
        {
            sourceContainer.Children.Remove(component);

            var dropPosition = e.GetPosition(targetContainer);
            int dropIndex = targetContainer.Children.Count;
            int targetIndex = _dashboardGrid.Children.IndexOf(targetContainer);

            //  Find drop index.
            for (int i = 0; i < targetContainer.Children.Count; i++)
            {
                UIElement child = targetContainer.Children[i];

                if (dropPosition.Y < child.TransformToAncestor(targetContainer).Transform(new Point(0, 0)).Y)
                {
                    dropIndex = i;
                    break;
                }
            }

            //  Drop component.
            targetContainer.Children.Insert(dropIndex, component);

            //  Fix components positions.
            var itemPosObject = _dashboardComponents.FirstOrDefault(i => i.FrameworkElement == component);

            if (itemPosObject != null)
            {
                itemPosObject.ColumnIndex = targetIndex;
                itemPosObject.Position = dropIndex;

                int fixedPosition = 0;

                //  Fix positions.
                foreach (var componentPos in _dashboardComponents.Where(i => i.ColumnIndex == targetIndex).OrderBy(i => i.Position))
                {
                    componentPos.Position = fixedPosition;
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update dashboard after resizing it. </summary>
        public void UpdateDashboardAfterResize()
        {
            if (HasColumnsAmoutChanged())
            {
                _columnsAmount = CalculateDashboardColumnsAmount();

                UpdateDashboardGridColumns();
                UpdateDashboardComponentsPosition();
            }
        }

        #endregion INTERACTION METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get current dashboard components positions. </summary>
        /// <returns> Current dashboard components positions. </returns>
        private List<DashboardComponentPosition> GetDashboardComponentsPositions()
        {
            var currentPositions = new List<DashboardComponentPosition>();

            return _dashboardContainers
                .SelectMany(kvp => ObjectHelper.GetChildComponents(kvp.Value).Select(c =>
                {
                    int position = ObjectHelper.GetComponentPositionInPanel(c);
                    return new DashboardComponentPosition(c, kvp.Key, position);
                }))
                .ToList();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Load components positions data. </summary>
        /// <param name="dashboardConfiguration"> Dashboard configuration data. </param>
        private void LoadComponentsPositions(DashboardConfig dashboardConfiguration)
        {
            //  Get components positions from configuration.
            var loadedPositions = dashboardConfiguration.ComponentsPosition
                .OrderBy(lc => lc.ColumnIndex)
                .ThenBy(lc => lc.Position);

            //  Get current components positions.
            var currentPositions = GetDashboardComponentsPositions()
                .OrderBy(cc => cc.ColumnIndex)
                .ThenBy(cc => cc.Position);

            //  Create result list.
            var dashboardComponents = new List<DashboardComponentPosition>();

            //  Select components positions.
            foreach (var componentPosition in currentPositions)
            {
                var inLoaded = loadedPositions.FirstOrDefault(lc => lc.Name == componentPosition.Name);
                dashboardComponents.Add(inLoaded ?? componentPosition);
            }

            int columnIndex = 0;
            int position = 0;

            //  Fix components positions.
            foreach (var componentPosition in dashboardComponents)
            {
                if (componentPosition.ColumnIndex != columnIndex)
                {
                    columnIndex = componentPosition.ColumnIndex;
                    position = 0;
                }

                if (componentPosition.FrameworkElement == null)
                    componentPosition.FrameworkElement = ObjectHelper.FindChildComponentByName<FrameworkElement>(
                        _dashboardGrid, componentPosition.Name);

                componentPosition.Position = position;
                position++;
            }

            //  Set final result.
            _dashboardComponents = dashboardComponents.OrderBy(rc => rc.ColumnIndex).ThenBy(rc => rc.Position).ToList();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Load dashboard components containers. </summary>
        private void LoadDashboardContainers()
        {
            var containers = ObjectHelper.GetChildComponents(_dashboardGrid);

            _dashboardContainers = containers.Where(c => c is StackPanel)
                .Select(c => (StackPanel)c)
                .ToDictionary(x => Grid.GetColumn(x));
        }

        #endregion SETUP METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Calculate dashboard columns amount availability. </summary>
        /// <returns> Amount of available columns. </returns>
        private int CalculateDashboardColumnsAmount()
        {
            return Math.Min(MAX_COLUMNS, (int)(_dashboardGrid.ActualWidth / COLUMN_MIN_WIDTH));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get component position in StackPanel. </summary>
        /// <param name="component"> Component. </param>
        /// <returns> Component position index. </returns>
        private static int GetComponentPositionInPanel(FrameworkElement component)
        {
            if (component == null)
                return -1;

            StackPanel parent = VisualTreeHelper.GetParent(component) as StackPanel;

            if (parent == null)
                return -1;

            if (parent is StackPanel stackPanel)
                return stackPanel.Children.IndexOf(component);

            return -1;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get dashboard components in particular column. </summary>
        /// <param name="columnIndex"> Dashboard column index. </param>
        /// <returns> List of dashboard components in column. </returns>
        private List<FrameworkElement> GetDashboardComponentsInColumn(int columnIndex)
        {
            if (_dashboardContainers.ContainsKey(columnIndex))
            {
                var container = _dashboardContainers[columnIndex];
                return ObjectHelper.GetChildComponents(container);
            }

            return new List<FrameworkElement>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if amount of available dashboard columns has been changed. </summary>
        /// <returns> True - amount of dashboard available columns has been changed; False - otherwise. </returns>
        private bool HasColumnsAmoutChanged()
        {
            var maxColumns = CalculateDashboardColumnsAmount();
            return maxColumns != _columnsAmount;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Move dashboard component between containers. </summary>
        /// <param name="sourceContainer"> Source dashboard container. </param>
        /// <param name="targetContainer"> Target dashboard container. </param>
        /// <param name="component"> Dashboard component to move. </param>
        /// <param name="positionIndex"> Target dashboard component position index. </param>
        private void MoveDashboardComponent(StackPanel sourceContainer, StackPanel targetContainer, 
            FrameworkElement component, int positionIndex)
        {
            sourceContainer.Children.Remove(component);
            targetContainer.Children.Insert(positionIndex, component);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update dashboard components positions. </summary>
        private void UpdateDashboardComponentsPosition()
        {
            int availableColumns = CalculateDashboardColumnsAmount();
            var notApplicableComponents = new List<DashboardComponentPosition>();

            //  Move components to it's propert available containers.
            foreach (var componentPosition in _dashboardComponents)
            {
                var currentPanel = ObjectHelper.FindParentComponent<StackPanel>(componentPosition.FrameworkElement);
                var destinationPanel = _dashboardContainers[componentPosition.ColumnIndex];

                if (componentPosition.ColumnIndex >= availableColumns)
                {
                    notApplicableComponents.Add(componentPosition);
                    continue;
                }

                MoveDashboardComponent(currentPanel, destinationPanel, componentPosition.FrameworkElement, componentPosition.Position);
            }

            int startColumn = 0;

            //  Move rest components from unavailable containers to available containers.
            foreach (var component in notApplicableComponents)
            {
                var currentPanel = ObjectHelper.FindParentComponent<StackPanel>(component.FrameworkElement);
                var destinationPanel = _dashboardContainers[startColumn];

                MoveDashboardComponent(currentPanel, destinationPanel, component.FrameworkElement, destinationPanel.Children.Count);

                startColumn++;

                if (startColumn >= availableColumns)
                    startColumn = 0;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update dashboard grid columns availability. </summary>
        /// <param name="availableColumnsAmount"> Amount of columns to be available. </param>
        private void UpdateDashboardGridColumns()
        {
            for (int columnIndex = 0; columnIndex < _dashboardGrid.ColumnDefinitions.Count; columnIndex++)
            {
                var columnDefinition = _dashboardGrid.ColumnDefinitions[columnIndex];

                var gridWidth = columnIndex < _columnsAmount
                    ? new GridLength(1, GridUnitType.Star)
                    : new GridLength(0, GridUnitType.Pixel);

                columnDefinition.Width = gridWidth;
            }
        }

        #endregion UTILITY METHODS

    }
}
