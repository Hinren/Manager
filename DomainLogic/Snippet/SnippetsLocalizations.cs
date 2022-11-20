using DomainLogic.Interfaces.Snippet;
using System.Reflection;

namespace DomainLogic.Snippet
{
    public class SnippetsLocalizations : ISnippetsPath
    {
        //TODO Think about how handle situation when is more than one version of visual studio actually is prefered one 

        private const string _universalFolderName = "My Code Snippets";
        private const string _CSSsnippet = "My CSS Snippets";
        private const string _HTMLsnippet = "My HTML Snippets";
        private const string _XAMLsnippet = "My XAML Snippets";
        private string _MyDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private const string _codeSnippetFolderName = "Code Snippets";
        private readonly string _getAssemlyEntry = Assembly.GetEntryAssembly().Location.Replace(@"\ProjectManager.dll", "");

        #region PathSnippets

        public string CsharpDestinationPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\Visual C#\{_universalFolderName}";

        public string CSSDestinationPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\Visual Web Developer\{_CSSsnippet}";

        public string HTMLDestinationPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\Visual Web Developer\{_HTMLsnippet}";

        public string JavaScriptDestinationPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\JavaScript\{_universalFolderName}";

        public string TypeScriptDestinationPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\TypeScript\{_universalFolderName}";

        public string XAMLDestinationPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\XAML\{_XAMLsnippet}";

        public string CsharpLocalAppPath() => Path.Combine(_getAssemlyEntry, "Snippet", "Csharp");

        public string CSSLocalAppPath() => Path.Combine(_getAssemlyEntry, "Snippet", "Css");

        public string HTMLLocalAppPath() => Path.Combine(_getAssemlyEntry, "Snippet", "Html");

        public string JavaScriptLocalAppPath() => Path.Combine(_getAssemlyEntry, "Snippet", "JavaScript");

        public string TypeScriptLocalAppPath() => Path.Combine(_getAssemlyEntry, "Snippet", "TypeScript");

        public string XAMLLocalAppPath() => Path.Combine(_getAssemlyEntry, "Snippet", "Xaml");

        #endregion

        #region Helper methods

        public string VisualStudioFolderName()
        {
            return "Visual Studio 2022";
            throw new NotImplementedException();
        }

        #endregion
    }
}
