using Common.Models.Snippet;
using DomainLogic.Interfaces.Snippet;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace DomainLogic.Snippet
{
    public class SnippetReader : ISnippetReader
    {
        private readonly string _getAssemlyEntry = Assembly.GetEntryAssembly().Location.Replace(@"\ProjectManager.dll", "");

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
            var snippets = new List<CodeSnippets>();
            var directories = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly).ToList();
            var filePaths = new List<string>();
            int count = directories.Count;
            for (int i = 0; i < count; i++)
            {
                var attributeFile = File.GetAttributes(directories[i]);
                if (attributeFile == FileAttributes.Directory)
                {
                    var directoriesInsideDirectory = Directory.GetDirectories(directories[i], "*", SearchOption.TopDirectoryOnly);
                    directories.AddRange(directoriesInsideDirectory);
                    count = directories.Count;
                }

                var files = Directory.GetFiles(directories[i]).Where(x => x.Contains(".snippet"));
                foreach (var filename in files)
                {
                    string filePath = filename.ToString();
                    snippets.Add(ReadSnippet(filePath));
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
