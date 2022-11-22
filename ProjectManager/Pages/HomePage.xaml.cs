using Common.Models.Snippet;
using DomainLogic.Snippet;
using Hinren.ProjectManager.Data.Settings;
using Hinren.ProjectManager.Pages.Base;
using System.IO;
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
            var test = new SnippetsLocalizations();

            var filePath = @"D:\Snipety porządek i nowe\DebuggerDisplayAttribute.snippet";

            // Declare this outside the 'using' block so we can access it later
            XmlSerializer serializer = new XmlSerializer(typeof(CodeSnippet));
            using (StringReader reader = new StringReader(filePath))
            {
                var test12 = (CodeSnippet)serializer.Deserialize(reader);
            }
            //using (var reader = new StreamReader(filePath))
            //{
            //    var test = (CodeSnippet)serializer.Deserialize(reader);
            //    snippetSaver.SaveSnippetOnLocalPath(test1212);
            //}

            var path = test.CsharpLocalAppPath();
        }
    }
}
