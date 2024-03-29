﻿using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.InternalMessages;
using MaterialDesignThemes.Wpf;
using ProjectManager.Components;
using ProjectManager.Data.Configuration;
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

namespace ProjectManager.InternalMessages
{
    public partial class StringInputIM : StandardInternalMessageEx
    {

        //  VARIABLES

        private bool _allowEmptyString = false;
        private string _defaultText;
        private string _description;
        private string _error;
        private string[] _forbiddenNames = new string[0];
        private bool _forbiddenNamesIgnoreCase = true;
        private string _text;


        //  GETTERS & SETTERS

        public bool AllowEmptyString
        {
            get => _allowEmptyString;
            set
            {
                _allowEmptyString = value;
                OnPropertyChanged(nameof(AllowEmptyString));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Error
        {
            get => _error;
            private set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }

        public string[] ForbiddenNames
        {
            get => _forbiddenNames;
            set
            {
                _forbiddenNames = value ?? new string[0];
                OnPropertyChanged(nameof(ForbiddenNames));
            }
        }

        public bool ForbiddenNamesIgnoreCase
        {
            get => _forbiddenNamesIgnoreCase;
            set
            {
                _forbiddenNamesIgnoreCase = value;
                OnPropertyChanged(nameof(ForbiddenNamesIgnoreCase));
            }
        }

        public string OryginalValue
        {
            get => _defaultText;
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> StringInputIM class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Internal Message title. </param>
        /// <param name="description"> Internal Message description. </param>
        /// <param name="iconKind"> Internal Message icon kind. </param>
        /// <param name="defaultText"> Default input text. </param>
        public StringInputIM(InternalMessagesExContainer parentContainer, string title, string description,
            PackIconKind iconKind = PackIconKind.EditBoxOutline, string defaultText = "") : base(parentContainer)
        {
            //  Initialize interface components.
            InitializeComponent();

            //  Interface configuration.
            Buttons = new InternalMessageButtons[]
            {
                InternalMessageButtons.OkButton,
                InternalMessageButtons.CancelButton
            };

            Title = title;
            Description = description;
            IconKind = iconKind;
            Text = defaultText;

            _defaultText = defaultText;
            OnPropertyChanged(nameof(OryginalValue));
        }

        #endregion CLASS METHODS

        #region BUTTONS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected override void OnOkClick(object sender, RoutedEventArgs e)
        {
            if (!ValidateEnteredString())
                return;

            base.OnOkClick(sender, e);
        }

        #endregion BUTTONS METHODS

        #region VALIDATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Validate if entered string is valid. </summary>
        /// <returns> True - string is valid; False - otherwise. </returns>
        private bool ValidateEnteredString()
        {
            if (!AllowEmptyString && string.IsNullOrEmpty(Text))
            {
                Error = $"Value can not be empty.";
                return false;
            }

            if (_forbiddenNames.Any(n => _forbiddenNamesIgnoreCase ? n.ToLower() == _text.ToLower() : n == _text))
            {
                Error = $"\"{Text}\" is already used, or is forbidden.";
                return false;
            }

            return true;
        }

        #endregion VALIDATION METHODS

    }
}
