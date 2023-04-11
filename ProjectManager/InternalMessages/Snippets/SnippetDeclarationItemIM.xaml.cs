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

namespace ProjectManager.InternalMessages.Snippets
{
    public partial class SnippetDeclarationItemIM : StandardInternalMessageEx
    {

        //  VARIABLES

        private string _error;
        private SnippetDeclaration _snippetDeclaration;
        private List<SnippetDeclaration> _snippetDeclarations;


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

        public SnippetDeclaration SnippetDeclaration
        {
            get => _snippetDeclaration;
            set
            {
                _snippetDeclaration = value;
                OnPropertyChanged(nameof(SnippetDeclaration));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetDeclarationItemIM class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="title"> Internal Message title. </param>
        /// <param name="iconKind"> Internal Message icon kind. </param>
        /// <param name="snippetDeclaration"> Snippet declaration item. </param>
        /// <param name="snippetDeclarations"> List of loaded snippet declarations. </param>
        public SnippetDeclarationItemIM(InternalMessagesExContainer parentContainer, string title,
            PackIconKind iconKind = PackIconKind.EditBoxOutline, SnippetDeclaration snippetDeclaration = null,
            List<SnippetDeclaration> snippetDeclarations = null) : base(parentContainer)
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

            SnippetDeclaration = snippetDeclaration;
            _snippetDeclarations = snippetDeclarations;
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
            if (SnippetDeclaration is SnippetLiteral snippetLiteral)
            {
                if (string.IsNullOrEmpty(snippetLiteral.ID))
                {
                    Error = "ID can not be empty.";
                    return false;
                }

                if (string.IsNullOrEmpty(snippetLiteral.Default))
                {
                    Error = "Default value can not be empty.";
                    return false;
                }

                if (_snippetDeclarations.Select(s => s as SnippetLiteral)
                    .Where(l => l != null).Any(l => l.ID.ToLower() == snippetLiteral.ID.ToLower()))
                {
                    Error = $"\"{snippetLiteral.ID}\" ID is already used in another declaration.";
                    return false;
                }
            }

            return true;
        }

        #endregion VALIDATION METHODS

    }
}
