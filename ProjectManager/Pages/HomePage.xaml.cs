using DomainLogic.Interfaces.Snippet;
using DomainLogic.Snippet;
using Hinren.ProjectManager.Data.Settings;
using Hinren.ProjectManager.Pages.Base;

namespace Hinren.ProjectManager.Pages
{
    public partial class HomePage : BasePage
    {
        //  METHODS
        private ISnippetSaver snippetSaver = new SnippetSaver();
        private ISnippetReader snippetReader = new SnippetReader();
        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> HomePage class constructor. </summary>
        /// <param name="pagesController"> Parent pages controller. </param>
        public HomePage(PagesControl pagesController) : base(pagesController)
        {
            InitializeComponent();
        }

        #endregion CLASS METHODS

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var config = ConfigurationManager.Instance;
            snippetSaver.SaveSnippetsOnLocalPath(@"D:\REPOSITORY\Snippets");
            snippetSaver.SaveSnippetsOnVisualStudioPath();
        }
    }
}
