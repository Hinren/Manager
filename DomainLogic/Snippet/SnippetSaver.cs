using Common.Models.Snippet;
using DomainLogic.Interfaces.Snippet;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace DomainLogic.Snippet
{
    public class SnippetSaver : ISnippetSaver
    {
        private readonly ISnippetsPath _snippetPath;
        private readonly ISnippetReader _snippetReader;
        private readonly Regex _getFileName = new Regex(@".*\\([^\\]+$)", RegexOptions.Compiled);
        private readonly string _getAssemlyEntry = Assembly.GetEntryAssembly().Location.Replace(@"\ProjectManager.dll", "");

        public SnippetSaver()
        {
            _snippetPath = new SnippetsLocalizations();
            _snippetReader = new SnippetReader();
        }

        public void SaveSnippetOnLocalPath(string path)
        {
            var snippets = _snippetReader.ReadSnippet(path);
            SaveSnippet(snippets);
        }

        public void SaveSnippetsOnLocalPath(string path)
        {
            var snippets = _snippetReader.ReadSnippets(path);
            foreach (var snippet in snippets)
                SaveSnippet(snippet);
        }

        public void SaveSnippetsOnLocalPath()
        {
            var snippets = _snippetReader.ReadSnippets();
            foreach (var snippet in snippets)
                SaveSnippet(snippet);
        }
        
        public void SaveSnippetsOnVisualStudioPath()
        {
            CreateFoldersIdDontExist(Path.Combine(_getAssemlyEntry, "Snippet"));
            string[] directories = Directory.GetDirectories(Path.Combine(_getAssemlyEntry, "Snippet"));
            foreach (var direct in directories)
            {
                string[] filePaths = Directory.GetFiles(direct);
                foreach (var filename in filePaths)
                {
                    string filePath = filename.ToString();
                    {
                        string destinationPath = string.Empty;
                        var condeSnippet = _snippetReader.ReadSnippet(filePath);
                        var fileName = _getFileName.Match(filePath).Groups[1].Value;
                        foreach (var codeSnippet in condeSnippet.CodeSnippet)
                        {
                            switch (codeSnippet.Snippet.Code.Language)
                            {
                                case "CSharp":
                                    destinationPath = Path.Combine(_snippetPath.CsharpDestinationPath(), fileName);
                                    break;
                                case "XAML":
                                    destinationPath = Path.Combine(_snippetPath.XAMLDestinationPath(), fileName);
                                    break;
                                case "css":
                                    destinationPath = Path.Combine(_snippetPath.CSSDestinationPath(), fileName);
                                    break;
                                case "html":
                                    destinationPath = Path.Combine(_snippetPath.HTMLDestinationPath(), fileName);
                                    break;
                                case "JavaScript":
                                    destinationPath = Path.Combine(_snippetPath.JavaScriptDestinationPath(), fileName);
                                    break;
                                case "TypeScript":
                                    destinationPath = Path.Combine(_snippetPath.TypeScriptDestinationPath(), fileName);
                                    break;
                                default:
                                    throw new NotImplementedException();
                            }
                            if (!File.Exists(destinationPath))
                                File.Copy(filePath, destinationPath);
                            //TODO Later replace snippet when is exist in destination files maybe remove and then make copy?
                            //else
                            //    File.Replace(filePath, destinationPath, null);
                        }
                    }
                }
            }
        }
        #region Helper methods

        private void SaveSnippet(CodeSnippets snippets, string path)
        {
            //If you make in one session twice then in second time you can't do it, because file is used by another process. I must find the reason 
            //Find all IDisopaple interface and making in using!!
            var xmlserializer = new XmlSerializer(typeof(CodeSnippets));
            var stringWriter = new Utf8StringWriter();
            var xml = "";

            foreach (var snnippet in snippets.CodeSnippet)
            {
                var newSnippets = new CodeSnippets() { CodeSnippet = new List<CodeSnippet>() { snnippet } };
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, newSnippets);
                    xml = stringWriter.ToString();
                }
                var destinationPath = path + "\\" + newSnippets.CodeSnippet[0].Header.Shortcut + ".snippet";
                File.WriteAllText(destinationPath, xml);
            }
        }

        private void CreateFoldersIdDontExist(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private void SaveSnippet(CodeSnippets snippet)
        {
            foreach (var codeSnippet in snippet.CodeSnippet)
            {
                string path = string.Empty;
                switch (codeSnippet.Snippet.Code.Language)
                {
                    case "CSharp":
                        path = _snippetPath.CsharpLocalAppPath();
                        break;
                    case "XAML":
                        path = _snippetPath.XAMLLocalAppPath();
                        break;
                    case "css":
                        path = _snippetPath.CSSLocalAppPath();
                        break;
                    case "html":
                        path = _snippetPath.HTMLLocalAppPath();
                        break;
                    case "JavaScript":
                        path = _snippetPath.JavaScriptLocalAppPath();
                        break;
                    case "TypeScript":
                        path = _snippetPath.TypeScriptDestinationPath();
                        break;
                    default:
                        throw new NotImplementedException();
                }
                var newSnippets = new CodeSnippets() { CodeSnippet = new List<CodeSnippet>() { codeSnippet } };
                CreateFoldersIdDontExist(path);
                SaveSnippet(newSnippets, path);
            }
        }

        #endregion
    }
}
