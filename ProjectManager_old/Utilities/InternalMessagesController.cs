using ExtendedControls.Events;
using ExtendedControls.InternalMessages;
using ExtendedControls.Static;
using Hinren.ProjectManager.Data.Settings;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static ExtendedControls.Events.Delegates;

namespace Hinren.ProjectManager.Utilities
{
    public class InternalMessagesController
    {

        //  VARIABLES

        private static InternalMessagesController instance;
        private ConfigurationManager configManager;

        public InternalMessagesContainer Container { get; private set; }


        //  GETTERS & SETTERS

        public static InternalMessagesController Instance
        {
            get
            {
                if (instance != null)
                    return instance;

                return null;
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Private InternalMessagesController singleton class constructor. </summary>
        /// <param name="container"> Internal Messages Container. </param>
        private InternalMessagesController(InternalMessagesContainer container)
        {
            configManager = ConfigurationManager.Instance;

            Container = container;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Initialization method for InternalMessagesController singleton. </summary>
        /// <param name="container"> Internal Messages Container. </param>
        /// <returns> InternalMessagesController initialized instance. </returns>
        public static InternalMessagesController Initialize(InternalMessagesContainer container)
        {
            instance = new InternalMessagesController(container);
            return instance;
        }

        #endregion CLASS METHODS

        #region CREATE MESSAGES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Show internal message box as information message. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="onCloseEvent"> On close internal message event. </param>
        /// <returns> InternalMessageBox. </returns>
        public InternalMessageBox ShowMessageBoxInfo(string title, string message,
            InternalMessageClose<InternalMessageCloseEventArgs> onCloseEvent = null)
        {
            var internalMessage = new InternalMessageBox(Container, title, message, PackIconKind.InfoCircleOutline);

            if (onCloseEvent != null)
                internalMessage.OnClose += onCloseEvent;

            UpdateInternalMessageBoxAppearance(internalMessage);
            Container.ShowMessage(internalMessage);

            return internalMessage;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show internal message box as alert message. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="onCloseEvent"> On close internal message event. </param>
        /// <returns> InternalMessageBox. </returns>
        public InternalMessageBox ShowMessageBoxAlert(string title, string message,
            InternalMessageClose<InternalMessageCloseEventArgs> onCloseEvent = null)
        {
            var internalMessage = new InternalMessageBox(Container, title, message, PackIconKind.AlertOutline);

            if (onCloseEvent != null)
                internalMessage.OnClose += onCloseEvent;

            UpdateInternalMessageBoxAppearance(internalMessage);
            Container.ShowMessage(internalMessage);

            return internalMessage;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show internal message box as error message. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="onCloseEvent"> On close internal message event. </param>
        /// <returns> InternalMessageBox. </returns>
        public InternalMessageBox ShowMessageBoxError(string title, string message,
            InternalMessageClose<InternalMessageCloseEventArgs> onCloseEvent = null)
        {
            var internalMessage = new InternalMessageBox(Container, title, message, PackIconKind.ErrorOutline);

            if (onCloseEvent != null)
                internalMessage.OnClose += onCloseEvent;

            UpdateInternalMessageBoxAppearance(internalMessage);
            Container.ShowMessage(internalMessage);

            return internalMessage;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show internal message box as error message. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="onCloseEvent"> On close internal message event. </param>
        /// <returns> InternalMessageBox. </returns>
        public InternalMessageBox ShowMessageBoxQuestion(string title, string message,
            InternalMessageClose<InternalMessageCloseEventArgs> onCloseEvent = null)
        {
            var internalMessage = new InternalMessageBox(Container, title, message,
                PackIconKind.QuestionMarkCircleOutline, InternalMessagesButtonsSet.YesNo);

            if (onCloseEvent != null)
                internalMessage.OnClose += onCloseEvent;

            UpdateInternalMessageBoxAppearance(internalMessage);
            Container.ShowMessage(internalMessage);

            return internalMessage;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show progress internal message box. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="onCloseEvent"> On close internal message event. </param>
        /// <param name="onHideEvent"> On hide internal message event. </param>
        /// <returns> InternalMessageBox. </returns>
        public ProgressInternalMessageBox ShowProgressMessageBox(string title, string message,
            InternalMessageClose<InternalMessageCloseEventArgs> onCloseEvent = null,
            InternalMessageHide onHideEvent = null)
        {
            var progressInternalMessage = new ProgressInternalMessageBox(Container, title, message);

            if (onCloseEvent != null)
                progressInternalMessage.OnClose += onCloseEvent;

            UpdateProgressInternalMessageBoxAppearance(progressInternalMessage);
            Container.ShowMessage(progressInternalMessage);

            return progressInternalMessage;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show internal message box as error message. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="onCloseEvent"> On close internal message event. </param>
        /// <returns> InternalMessageBox. </returns>
        public FilesSelectorInternalMessageBox ShowOpenFileMessageBox(string title,
            InternalMessageClose<FilesSelectorInternalMessageCloseEventArgs> onCloseEvent = null)
        {
            var filesSelectorInternalMessage = FilesSelectorInternalMessageBox
                .CreateOpenFileInternalMessageEx(Container, title);

            if (onCloseEvent != null)
                filesSelectorInternalMessage.OnClose += onCloseEvent;

            UpdateFilesSelectorInternalMessageBoxAppearance(filesSelectorInternalMessage);
            Container.ShowMessage(filesSelectorInternalMessage);

            return filesSelectorInternalMessage;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show internal message box as error message. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="onCloseEvent"> On close internal message event. </param>
        /// <returns> InternalMessageBox. </returns>
        public FilesSelectorInternalMessageBox ShowSaveFileMessageBox(string title,
            InternalMessageClose<FilesSelectorInternalMessageCloseEventArgs> onCloseEvent = null)
        {
            var filesSelectorInternalMessage = FilesSelectorInternalMessageBox
                .CreateSaveFileInternalMessageEx(Container, title);

            if (onCloseEvent != null)
                filesSelectorInternalMessage.OnClose += onCloseEvent;

            UpdateFilesSelectorInternalMessageBoxAppearance(filesSelectorInternalMessage);
            Container.ShowMessage(filesSelectorInternalMessage);

            return filesSelectorInternalMessage;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show internal message box as error message. </summary>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="onCloseEvent"> On close internal message event. </param>
        /// <returns> InternalMessageBox. </returns>
        public FilesSelectorInternalMessageBox ShowSelectDirectoryMessageBox(string title,
            InternalMessageClose<FilesSelectorInternalMessageCloseEventArgs> onCloseEvent = null)
        {
            var filesSelectorInternalMessage = FilesSelectorInternalMessageBox
                .CreateSelectDirectoryInternalMessageEx(Container, title);

            if (onCloseEvent != null)
                filesSelectorInternalMessage.OnClose += onCloseEvent;

            UpdateFilesSelectorInternalMessageBoxAppearance(filesSelectorInternalMessage);
            Container.ShowMessage(filesSelectorInternalMessage);

            return filesSelectorInternalMessage;
        }

        #endregion CREATE MESSAGES METHODS

        #region UPDATE MESSAGES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update InternalMessageBox appearance. </summary>
        /// <param name="message"> InternalMessageBox. </param>
        private void UpdateInternalMessageBoxAppearance<T>(BaseInternalMessage<T> message) where T : InternalMessageCloseEventArgs
        {
            message.Background = configManager.AppearanceBackgroundBrush;
            message.BorderBrush = configManager.AppearanceAccentColorBrush;
            message.Foreground = configManager.AppearanceForegroundBrush;
            message.ButtonBackgroundBrush = configManager.AppearanceAccentColorBrush;
            message.ButtonBorderBrush = configManager.AppearanceAccentColorBrush;
            message.ButtonForegroundBrush = configManager.AppearanceAccentForegroundBrush;
            message.ButtonBackgroundMouseOverBrush = configManager.AppearanceAccentMouseOverBrush;
            message.ButtonBorderMouseOverBrush = configManager.AppearanceAccentMouseOverBrush;
            message.ButtonForegroundMouseOverBrush = configManager.AppearanceAccentForegroundBrush;
            message.ButtonBackgroundPressedBrush = configManager.AppearanceAccentPressedBrush;
            message.ButtonBorderPressedBrush = configManager.AppearanceAccentPressedBrush;
            message.ButtonForegroundPressedBrush = configManager.AppearanceAccentForegroundBrush;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update ProgressInternalMessageBox appearance. </summary>
        /// <param name="message"> ProgressInternalMessageBox. </param>
        private void UpdateProgressInternalMessageBoxAppearance(ProgressInternalMessageBox message)
        {
            UpdateInternalMessageBoxAppearance(message);

            message.ProgressBarBackgroundBrush = new SolidColorBrush(Colors.Transparent);
            message.ProgressBarBorderBrush = configManager.AppearanceAccentColorBrush;
            message.ProgressBarProgressBrush = configManager.AppearanceAccentColorBrush;
        }

        //  --------------------------------------------------------------------------------
        private void UpdateFilesSelectorInternalMessageBoxAppearance(FilesSelectorInternalMessageBox message)
        {
            UpdateInternalMessageBoxAppearance(message);

            message.TextBoxBackgroundMouseOverBrush = configManager.AppearanceAccentMouseOverBrush;
            message.TextBoxBorderMouseOverBrush = configManager.AppearanceAccentMouseOverBrush;
            message.TextBoxForegroundMouseOverBrush = configManager.AppearanceAccentForegroundBrush;
            message.TextBoxBackgroundSelectedBrush = configManager.AppearanceBackgroundBrush;
            message.TextBoxBorderSelectedBrush = configManager.AppearanceAccentSelectedBrush;
            message.TextBoxForegroundSelectedBrush = configManager.AppearanceForegroundBrush;
            message.TextBoxTextSelectedBrush = configManager.AppearanceAccentSelectedBrush;
        }

        #endregion UPDATE MESSAGES METHODS

    }
}
