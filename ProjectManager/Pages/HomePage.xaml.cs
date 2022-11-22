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
            var test = new SnippetsLocalizations();

            var filePath = @"D:\Snipety porządek i nowe\property_long.snippet";

            // Declare this outside the 'using' block so we can access it later
            //XmlSerializer serializer = new XmlSerializer(typeof(CodeSnippet));

            using (var sr = new StreamReader(filePath))
            {
                // Read the stream as a string, and write the string to the console.
                var sefsd = sr.ReadToEnd();
                XmlSerializer serializer = new XmlSerializer(typeof(CodeSnippet));
                MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(sefsd));
                var resultingMessage = (CodeSnippets)serializer.Deserialize(memStream);
            }

            //using (StringReader reader = new StringReader(filePath))
            //{
            //    var xml = reader.ReadToEnd();
            //    var test12 = (CodeSnippets)serializer.Deserialize(reader);
            //}
            //using (var reader = new StreamReader(filePath))
            //{
            //    var test = (CodeSnippet)serializer.Deserialize(reader);
            //    snippetSaver.SaveSnippetOnLocalPath(test1212);
            //}

            var path = test.CsharpLocalAppPath();
        }
    }
}
