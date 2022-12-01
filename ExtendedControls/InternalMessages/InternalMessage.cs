using ExtendedControls.Events;
using ExtendedControls.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ExtendedControls.InternalMessages
{
    public class InternalMessage : BaseInternalMessage<InternalMessageCloseEventArgs>
    {

        //  VARIABLES

        protected InternalMessageButtons[] _buttons = new InternalMessageButtons[0];


        //  GETTERS & SETTERS

        public InternalMessageButtons[] Buttons
        {
            get => _buttons;
            set
            {
                _buttons = value;
                OnPropertyChanged(nameof(Buttons));

                if (IsLoadingComplete)
                    SetButtons(value);
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessage class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        public InternalMessage(InternalMessagesContainer parentContainer) : base(parentContainer)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static InternalMessage class constructor. </summary>
        static InternalMessage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InternalMessage),
                new FrameworkPropertyMetadata(typeof(InternalMessage)));
        }

        #endregion CLASS METHODS

        #region BUTTONS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnOkClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Ok;
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Yes Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnYesClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Yes;
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking No Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnNoClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.No;
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Cancel Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Cancel;
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Hide Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnHideClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        #endregion BUTTONS METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            var buttonHide = GetExtButton("hideButton");
            ApplyExtButtonClickMethod(buttonHide, OnHideClick);

            OnAllowHideUpdate(AllowHide);
            SetButtons(_buttons);

            ApplyExtButtonClickMethod(GetExtButton("okButton"), OnOkClick);
            ApplyExtButtonClickMethod(GetExtButton("yesButton"), OnYesClick);
            ApplyExtButtonClickMethod(GetExtButton("noButton"), OnNoClick);
            ApplyExtButtonClickMethod(GetExtButton("cancelButton"), OnCancelClick);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set specified buttons set to be visible in Internal Message. </summary>
        /// <param name="buttons"> Set of buttons to be visible in Internal Message. </param>
        private void SetButtons(InternalMessageButtons[] buttons)
        {
            foreach (var buttonType in (InternalMessageButtons[])Enum.GetValues(typeof(InternalMessageButtons)))
            {
                ExtButton button = null;
                bool showHide = buttons.Any(bt => bt == buttonType);

                switch (buttonType)
                {
                    case InternalMessageButtons.CancelButton:
                        button = GetExtButton("cancelButton");
                        break;

                    case InternalMessageButtons.NoButton:
                        button = GetExtButton("noButton");
                        break;

                    case InternalMessageButtons.OkButton:
                        button = GetExtButton("okButton");
                        break;

                    case InternalMessageButtons.YesButton:
                        button = GetExtButton("yesButton");
                        break;
                }

                if (button != null)
                    button.Visibility = showHide ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing AllowHide property. </summary>
        /// <param name="showHide"> True - allow hide; False - otherwise. </param>
        protected override void OnAllowHideUpdate(bool showHide = false)
        {
            var buttonHide = GetExtButton("hideButton");
            buttonHide.Visibility = showHide ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion TEMPLATE METHODS

    }
}
