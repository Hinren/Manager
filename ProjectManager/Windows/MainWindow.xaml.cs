using Hinren.ProjectManager.Pages;
using Hinren.ProjectManager.Pages.Base;
using System.Windows;

namespace Hinren.ProjectManager.Windows
{
    public partial class MainWindow : Window
    {

        //  VARIABLES

        //  GETTERS & SETTERS

        public PagesControl PagesController
        {
            get => pagesControl;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MainWindow class constructor. </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region WINDOW METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading window. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PagesController.LoadPage<HomePage>();
        }

        #endregion WINDOW METHODS

    }
}
