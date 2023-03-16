using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.InternalMessages;
using MaterialDesignThemes.Wpf;
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

        private string _description;
        private string _text;


        //  GETTERS & SETTERS

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
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
        }

        #endregion CLASS METHODS

    }
}
