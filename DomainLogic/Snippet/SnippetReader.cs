using Common.Models.Snippet;
using DomainLogic.Interfaces.Snippet;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace DomainLogic.Snippet
{
    public class SnippetReader : ISnippetReader
    {
        private readonly ISnippetsPath _snippetPath;
        private readonly Regex _getFileName = new Regex(@".*\\([^\\]+$)", RegexOptions.Compiled);
        private readonly string _getAssemlyEntry = Assembly.GetEntryAssembly().Location.Replace(@"\ProjectManager.dll", "");

        public SnippetReader()
        {
            _snippetPath = new SnippetsLocalizations();
        }

        public CodeSnippets ReadSnippet(string path)
        {
            return GetCodeSnippetsStructure(path);
        }

        private CodeSnippets GetCodeSnippetsStructure(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CodeSnippets));

            StreamReader reader = new StreamReader(path);
            return (CodeSnippets)serializer.Deserialize(reader);
        }

        public List<CodeSnippets> ReadSnippets(string path)
        {
            //Making better... Here can be folder inside folders so is very important do search every folder to find folder with excension .snippet. Also later 
            //is important too add validation for checking format files. We don't want anything else. Here is only importat .snippet
            var snippets = new List<CodeSnippets>();
            var directories = path.Contains("Snippet") ? Directory.GetDirectories(path) : Directory.GetDirectories(path, "Snippet");
            //string[] directories = Directory.GetDirectories(path, "Snippet");
            foreach (var direct in directories)
            {
                if (!direct.Contains(".git"))
                {
                    string[] filePaths = Directory.GetFiles(direct);
                    foreach (var filename in filePaths)
                    {
                        string filePath = filename.ToString();
                        snippets.Add(ReadSnippet(filePath));
                    }
                }
            }

            return snippets;
        }

        public List<CodeSnippets> ReadSnippets()
        {
            var snippets = new List<CodeSnippets>();
            string[] directories = Directory.GetDirectories(_getAssemlyEntry, "Snippet");
            foreach (var direct in directories)
            {
                string[] filePaths = Directory.GetFiles(direct);
                foreach (var filename in filePaths)
                {
                    string filePath = filename.ToString();
                    snippets.Add(ReadSnippet(filePath));
                }
            }

            return snippets;
        }
    }
}
