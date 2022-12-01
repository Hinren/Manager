using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows;
using ExtendedControls.Events;

namespace ExtendedControls.InternalMessages
{
    public class InternalMessagesContainer : Control, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private Frame _contentFrame;
        private List<IInternalMessage> _loadedMessages;


        //  GETTERS & SETTERS

        public bool CanGoBack
        {
            get => CurrentMessageIndex > 0;
        }

        public IInternalMessage CurrentMessage
        {
            get => _contentFrame.Content != null ? _contentFrame.Content as IInternalMessage : null;
        }

        public int CurrentMessageIndex
        {
            get => CurrentMessage != null ? _loadedMessages.IndexOf(CurrentMessage) : -1;
        }

        public bool HasHidden
        {
            get => _loadedMessages != null && _loadedMessages.Any(m => m.IsHidden);
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessagesContainer class constructor. </summary>
        public InternalMessagesContainer()
        {
            //  Initialize data containers.
            _loadedMessages = new List<IInternalMessage>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static InternalMessagesContainer class constructor. </summary>
        static InternalMessagesContainer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InternalMessagesContainer),
                new FrameworkPropertyMetadata(typeof(InternalMessagesContainer)));
        }

        #endregion CLASS METHODS

        #region INTERFACE MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Hide internal messages container interface. </summary>
        private void HideInterface()
        {
            if (Visibility == Visibility.Visible)
                Visibility = Visibility.Collapsed;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show internal messages container interface. </summary>
        private void ShowInterface()
        {
            if (Visibility != Visibility.Visible)
                Visibility = Visibility.Visible;
        }

        #endregion INTERFACE MANAGEMENT METHODS

        #region MESSAGES MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after complete navigation to diffrent message. </summary>
        /// <param name="sender"> Object that invoked an event. </param>
        /// <param name="e"> Navigation event arguemnts. </param>
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            //  Remove back entry pages from content frame.
            ClearBackEntry();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove previous pages from content fram back entry. </summary>
        private void ClearBackEntry()
        {
            //  Get previous pages from content frame navigation service.
            var backEntry = _contentFrame.NavigationService.RemoveBackEntry();

            //  While previous pages are available - try to remove it.
            while (backEntry != null)
                backEntry = _contentFrame.NavigationService.RemoveBackEntry();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove all loaded messages. </summary>
        private void ClearMessages()
        {
            _contentFrame.Content = null;
            ClearBackEntry();
            _loadedMessages.Clear();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoking from InternalMessage for close it. </summary>
        /// <param name="message"> InternalMessage to close. </param>
        internal void CloseMessage<T>(BaseInternalMessage<T> message) where T : InternalMessageCloseEventArgs
        {
            if (IsMessageLoaded<T>(message) && CurrentMessage == message)
            {
                var index = _loadedMessages.IndexOf(message);
                var isNotLast = _loadedMessages.LastOrDefault() != message;

                _loadedMessages.Remove(message);

                if (isNotLast)
                {
                    var nextMessage = _loadedMessages[index];

                    if (nextMessage.IsHidden)
                        nextMessage.Show();
                }
                else
                {
                    var prevIndex = index - 1;

                    if (prevIndex >= 0)
                    {
                        var prevMessage = _loadedMessages[prevIndex];

                        if (prevMessage.IsHidden)
                            prevMessage.Show();
                        else
                            _contentFrame.Navigate(prevMessage);
                    }
                    else
                    {
                        ClearMessages();
                        HideInterface();
                    }
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoking from InternalMessage for hide it. </summary>
        /// <param name="message"> InternalMessage to hide. </param>
        internal void HideMessage<T>(BaseInternalMessage<T> message) where T : InternalMessageCloseEventArgs
        {
            if (IsMessageLoaded(message) && CurrentMessage == message)
            {
                var prevIndex = _loadedMessages.IndexOf(message) - 1;

                if (prevIndex >= 0)
                {
                    var prevMessage = _loadedMessages[prevIndex];

                    if (prevMessage.IsHidden)
                        prevMessage.Show();
                    else
                        _contentFrame.Navigate(prevMessage);
                }
                else
                {
                    HideInterface();
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if InternalMessage is currently loaded. </summary>
        /// <param name="message"> InternalMessage. </param>
        /// <returns> True - message is loaded; False - otherwise. </returns>
        private bool IsMessageLoaded<T>(BaseInternalMessage<T> message) where T : InternalMessageCloseEventArgs
        {
            return _loadedMessages.Any(m => m == message);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show last hidden InternalMessage. </summary>
        public void ShowLastHiddenMessage()
        {
            if (_loadedMessages.Any())
            {
                if (_loadedMessages.Last().IsHidden || Visibility != Visibility.Visible)
                {
                    _loadedMessages.Last(m => m.IsHidden).Show();
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Load and show InternalMessage. </summary>
        /// <param name="message"> InternalMessage. </param>
        public void ShowMessage<T>(BaseInternalMessage<T> message) where T : InternalMessageCloseEventArgs
        {
            if (!IsMessageLoaded(message))
                _loadedMessages.Add(message);

            _contentFrame.Navigate(message);
            ShowInterface();
        }

        #endregion MESSAGES MANAGEMENT

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            //  Setup content frame
            _contentFrame = GetFrame("contentFrame");
            _contentFrame.Navigated += ContentFrame_Navigated;

            this.Visibility = Visibility.Collapsed;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ButtonEx from ContentTemplate. </summary>
        /// <param name="buttonName"> ButtonEx name. </param>
        /// <returns> ButtonEx or null. </returns>
        protected Frame GetFrame(string frameName)
        {
            return this.Template.FindName(frameName, this) as Frame;
        }

        #endregion TEMPLATE METHODS

    }
}
