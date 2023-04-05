using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.InternalMessages;
using MaterialDesignThemes.Wpf;
using SnippetsManager.Models;
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
using static System.Net.Mime.MediaTypeNames;

namespace ProjectManager.InternalMessages.Snippets
{
    public partial class SnippetImportItemIM : StandardInternalMessageEx
    {

        //  VARIABLES

        private string _error;
        private SnippetImport _snippetImport;
        private List<SnippetImport> _snippetImports;


        //  GETTERS & SETTERS

        public string Error
        {
            get => _error;
            private set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }

        public SnippetImport SnippetImport
        {
            get => _snippetImport;
            set
            {
                _snippetImport = value;
                OnPropertyChanged(nameof(SnippetImport));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetImportItemIM class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Internal Message title. </param>
        /// <param name="iconKind"> Internal Message icon kind. </param>
        /// <param name="snippetImport"> Snippet import item. </param>
        public SnippetImportItemIM(InternalMessagesExContainer parentContainer, string title,
            PackIconKind iconKind = PackIconKind.EditBoxOutline, SnippetImport snippetImport = null,
            List<SnippetImport> snippetImports = null) : base(parentContainer)
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
            IconKind = iconKind;

            SnippetImport = snippetImport;
            _snippetImports = snippetImports;
        }

        #endregion CLASS METHODS

        #region BUTTONS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected override void OnOkClick(object sender, RoutedEventArgs e)
        {
            if (!ValidateModel())
                return;

            base.OnOkClick(sender, e);
        }

        #endregion BUTTONS METHODS

        #region VALIDATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Validate if entered data are valid. </summary>
        /// <returns> True - data are valid; False - otherwise. </returns>
        private bool ValidateModel()
        {
            if (string.IsNullOrEmpty(SnippetImport.Namespace))
            {
                Error = "Namespace can not be empty.";
                return false;
            }

            if (_snippetImports?.Any(i => i.Namespace.ToLower() == SnippetImport.Namespace.ToLower()) == true)
            {
                Error = $"\"{SnippetImport.Namespace}\" namespace is already used in another import.";
                return false;
            }

            return true;
        }

        #endregion VALIDATION METHODS

    }
}
