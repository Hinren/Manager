using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ProjectManager.Utilities
{
    public class ApplicationHelper
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
        /// <summary> Get application assembly name. </summary>
        /// <returns> Application assembly name. </returns>
        public static string GetApplicationDescription()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var attributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), true);

            if (attributes.Length > 0)
                return ((AssemblyDescriptionAttribute)attributes.FirstOrDefault())?.Description;

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

        #region WINDOW POSITIONING METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Adjust window size and location that will fit into primary screen. </summary>
        /// <param name="window"> Window to resize and relocation. </param>
        public static void AdjustWindowToPrimaryScreen(Window window)
        {
            AdjustWindowToScreen(window, Screen.PrimaryScreen);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Adjust window size and location that will fit into screen. </summary>
        /// <param name="window"> Window to resize and relocation. </param>
        /// <param name="destScreen"> Destination screen. </param>
        public static void AdjustWindowToScreen(Window window, Screen destScreen)
        {
            if (destScreen == null)
                return;

            double x = window.Left;
            double y = window.Top;
            double height = window.ActualHeight;
            double width = window.ActualWidth;

            if (x + width > destScreen.WorkingArea.X + destScreen.WorkingArea.Width)
                x = destScreen.WorkingArea.Width - width
                    + (destScreen.Bounds.Width - destScreen.WorkingArea.Width);

            if (x < destScreen.WorkingArea.X)
                x = destScreen.WorkingArea.X;

            if (y + height > destScreen.WorkingArea.Y + destScreen.WorkingArea.Height)
                y = destScreen.WorkingArea.Height - height
                    + (destScreen.Bounds.Height - destScreen.WorkingArea.Height);

            if (y < destScreen.WorkingArea.Y)
                y = destScreen.WorkingArea.Y;

            if (y > destScreen.WorkingArea.Height)
                height = destScreen.WorkingArea.Height;

            if (x > destScreen.WorkingArea.Width)
                width = destScreen.WorkingArea.Width;

            window.Left = x;
            window.Top = y;
            window.Height = height;
            window.Width = width;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Calculater center position of window on particular screen. </summary>
        /// <param name="windowSize"> Size of window. </param>
        /// <param name="destScreen"> Destination screen (or use null to select primary). </param>
        /// <returns> Calculated window position. </returns>
        public static Point GetWindowCenterPosition(Window window, Screen destScreen = null)
        {
            return GetWindowCenterPosition(
                new Size(window.Width, window.Height), destScreen);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Calculater center position of window on particular screen. </summary>
        /// <param name="windowSize"> Size of window. </param>
        /// <param name="destScreen"> Destination screen (or use null to select primary). </param>
        /// <returns> Calculated window position. </returns>
        public static Point GetWindowCenterPosition(Size windowSize, Screen destScreen = null)
        {
            var screen = destScreen ?? Screen.PrimaryScreen;

            double left = (screen.WorkingArea.Width - windowSize.Width) / 2;
            double top = (screen.WorkingArea.Height - windowSize.Height) / 2;

            return new Point(screen.WorkingArea.Left + left, screen.WorkingArea.Top + top);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get screen where window is placed. </summary>
        /// <param name="window"> Window </param>
        /// <returns> Screen where window is placed. </returns>
        public static Screen GetScreenWhereIsWindow(Window window)
        {
            double centerX = window.Left + (window.Width / 2);
            double centerY = window.Top + (window.Height / 2);

            foreach (var screen in Screen.AllScreens)
            {
                double rightBound = screen.Bounds.X + screen.Bounds.Width;
                double bottomBound = screen.Bounds.Y + screen.Bounds.Height;

                if (centerX >= screen.Bounds.X && centerX < rightBound
                    && centerY >= screen.Bounds.Y && centerY < bottomBound)
                    return screen;
            }

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if window control is in rage of screen that user can interact with it. </summary>
        /// <param name="window"> Window </param>
        /// <param name="controlHeight"> Height of window control. </param>
        /// <returns> True - window control is in range of one of screens; False - otherwise. </returns>
        public static bool WindowControlIsAccesable(Window window, double controlHeight = 30)
        {
            var leftPoint = new Point(window.Left, window.Top + controlHeight);
            var rightPoint = new Point(window.Left + window.Width, window.Top + controlHeight);

            foreach (var screen in Screen.AllScreens)
            {
                double rightBound = screen.Bounds.X + screen.Bounds.Width;
                double bottomBound = screen.Bounds.Y + screen.Bounds.Height;

                if (leftPoint.X > screen.Bounds.X && leftPoint.X < rightBound
                    && leftPoint.Y > screen.Bounds.Y && leftPoint.Y < bottomBound - controlHeight)
                    return true;

                if (rightPoint.X > screen.Bounds.X && rightPoint.X < rightBound
                    && rightPoint.Y > screen.Bounds.Y && rightPoint.Y < bottomBound - controlHeight)
                    return true;
            }

            return false;
        }

        #endregion WINDOW POSITIONING METHODS

    }
}
