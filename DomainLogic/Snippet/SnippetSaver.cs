using Common.Models.Snippet;
using DomainLogic.Interfaces.Snippet;
using DomainModel.Models;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace DomainLogic.Snippet
{
    public class SnippetSaver : ISnippetSaver
    {
        private readonly ISnippetsPath _snippetPath;
        private readonly Regex _getFileName = new Regex(@".*\\([^\\]+$)", RegexOptions.Compiled);
        private readonly string _getAssemlyEntry = Assembly.GetEntryAssembly().Location.Replace(@"\ProjectManager.dll", "");

        public SnippetSaver()
        {
            _snippetPath = new SnippetsLocalizations();
        }

        public void SaveSnippetOnLocalPath(CodeSnippets snippet)
        {
            SaveSnippet(snippet);
        }

        public void SaveSnippetsOnLocalPath(List<CodeSnippets> snippets)
        {
            foreach (var snippet in snippets)
                SaveSnippet(snippet);
        }

        public void SaveSnippetsOnVisualStudioPath()
        {
            CreateFoldersIdDontExist(Path.Combine(_getAssemlyEntry, "Snippet"));
            string[] directories = Directory.GetDirectories(_getAssemlyEntry, "Snippet");
            foreach (var direct in directories)
            {
                string[] filePaths = Directory.GetFiles(direct);
                foreach (var filename in filePaths)
                {
                    string filePath = filename.ToString();

                    XmlSerializer reader = new XmlSerializer(typeof(CodeSnippets));
                    using (StreamReader readSnippet = new StreamReader(filePath))
                    {
                        string destinationPath = string.Empty;
                        var condeSnippet = (CodeSnippets)reader.Deserialize(readSnippet);
                        var fileName = _getFileName.Match(filePath).Value;
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
                            else
                                File.Replace(filePath, destinationPath, null);
                        }
                    }
                }
            }
        }
        #region Helper methods

        private void SaveSnippet(CodeSnippet snippet, string path)
        {
            var newSnippets = new CodeSnippets() { CodeSnippet = new List<CodeSnippet>() { snippet} };
            var xmlserializer = new XmlSerializer(typeof(CodeSnippets));
            var stringWriter = new Utf8StringWriter();
            var xml = "";

            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, newSnippets);
                xml = stringWriter.ToString();
            }
            var destinationPath = path + "\\" + newSnippets.CodeSnippet[0].Header.Shortcut + ".snippet";
            File.WriteAllText(destinationPath, xml);
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
                CreateFoldersIdDontExist(path);
                SaveSnippet(codeSnippet, path);
            }
        }

        #endregion
    }
}
