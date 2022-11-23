using Common.Models.Snippet;
using DomainLogic.Snippet;
using Hinren.ProjectManager.Data.Settings;
using Hinren.ProjectManager.Pages.Base;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Hinren.ProjectManager.Pages
{
    public partial class HomePage : BasePage
    {
        //  METHODS
        private SnippetSaver snippetSaver = new SnippetSaver();
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
            //temporary testing logic here
            //var filePath = @"D:\Snipety porządek i nowe\property_long.snippet";

            //var snippet = new CodeSnippets();
            //using (var sr = new StreamReader(filePath))
            //{
            //    XmlSerializer serializer = new XmlSerializer(typeof(CodeSnippets));

            //    StreamReader reader = new StreamReader(filePath);
            //    snippet = (CodeSnippets)serializer.Deserialize(reader);
            //}

            //snippetSaver.SaveSnippetOnLocalPath(snippet);

        }
    }
}
