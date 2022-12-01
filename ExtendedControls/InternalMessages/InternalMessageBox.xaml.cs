using ExtendedControls.Static;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExtendedControls.InternalMessages
{
    public partial class InternalMessageBox : InternalMessage
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            nameof(Message),
            typeof(string),
            typeof(InternalMessageBox),
            new PropertyMetadata(string.Empty));


        //  GETTERS & SETTERS

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set
            {
                SetValue(MessageProperty, value);
                OnPropertyChanged(nameof(Message));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Message title. </param>
        /// <param name="message"> Message. </param>
        /// <param name="icon"> Message header icon kind. </param>
        /// <param name="buttonsSet"> Set of buttons. </param>
        public InternalMessageBox(InternalMessagesContainer parentContainer, string title, string message,
            PackIconKind icon = PackIconKind.None, InternalMessagesButtonsSet buttonsSet = InternalMessagesButtonsSet.Ok) 
            : base(parentContainer)
        {
            Title = title;
            Message = message;
            IconKind = icon;
            SetButtonsSet(buttonsSet);

            //  Initialize interface components.
            InitializeComponent();
        }
        
        #endregion CLASS METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup buttons using InternalMessagesButtonsSet enum. </summary>
        /// <param name="buttonsSet"> InternalMessagesButtonsSet. </param>
        private void SetButtonsSet(InternalMessagesButtonsSet buttonsSet)
        {
            switch (buttonsSet)
            {
                case InternalMessagesButtonsSet.Ok:
                    Buttons = new InternalMessageButtons[]
                    {
                        InternalMessageButtons.OkButton
                    };
                    break;

                case InternalMessagesButtonsSet.OkCancel:
                    Buttons = new InternalMessageButtons[]
                    {
                        InternalMessageButtons.OkButton,
                        InternalMessageButtons.CancelButton
                    };
                    break;

                case InternalMessagesButtonsSet.YesNo:
                    Buttons = new InternalMessageButtons[]
                    {
                        InternalMessageButtons.YesButton,
                        InternalMessageButtons.NoButton
                    };
                    break;

                case InternalMessagesButtonsSet.YesNoCancel:
                    Buttons = new InternalMessageButtons[]
                    {
                        InternalMessageButtons.YesButton,
                        InternalMessageButtons.NoButton,
                        InternalMessageButtons.CancelButton
                    };
                    break;
            }
        }

        #endregion TEMPLATE METHODS

    }
}
