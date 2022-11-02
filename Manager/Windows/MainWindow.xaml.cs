using chkam05.Tools.ControlsEx.InternalMessages;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Manager.Windows
{
    public partial class MainWindow : Window
    {

        public InternalMessagesExContainer InternalMessagesContainer
        {
            get => internalMessagesContainer;
        }


        #region WINDOW METHODS

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowHelloMessage();
        }

        #endregion WINDOW METHODS

        #region HELLO METHODS

        private void ShowHelloMessage()
        {
            var app = (App)Application.Current;

            string messageContent = app.GetApplicationName()
                + Environment.NewLine
                + app.GetApplicationCompany()
                + Environment.NewLine
                + app.GetApplicationCopyright()
                + Environment.NewLine
                + app.GetApplicationVersion().ToString();

            var message = InternalMessageEx.CreateInfoMessage(
                InternalMessagesContainer, $"Welcome in {app.GetApplicationTitle()}", messageContent);

            message.IconKind = PackIconKind.Smiley;

            InternalMessagesContainer.ShowMessage(message);
        }

        #endregion HELLO METHODS

    }
}
