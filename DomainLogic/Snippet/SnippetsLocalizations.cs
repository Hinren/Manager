using DomainLogic.Interfaces.Snippet;

namespace DomainLogic.Snippet
{
    public class SnippetsLocalizations : ISnippetsLocalizations
    {
        //TODO Think about how handle situation when is more than one version of visual studio actually is prefered one 

        private const string _universalFolderName = "My Code Snippets";
        private const string _CSSsnippet = "My CSS Snippets";
        private const string _HTMLsnippet = "My HTML Snippets";
        private const string _XAMLsnippet = "My XAML Snippets";
        private string _MyDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private const string _codeSnippetFolderName = "Code Snippets";

        public string CsharpPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\Visual C#\{_universalFolderName}";

        public string CSSPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\Visual Web Developer\{_CSSsnippet}";

        public string HTMLPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\Visual Web Developer\{_HTMLsnippet}";

        public string JavaScriptPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\JavaScript\{_universalFolderName}";

        public string TypeScriptPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\TypeScript\{_universalFolderName}";

        public string XAMLPath() => $@"{_MyDocumentPath}\{VisualStudioFolderName()}\{_codeSnippetFolderName}\XAML\{_XAMLsnippet}";

        public string VisualStudioFolderName()
        {
            //logic 
            //check here _MyDocumentPath
            throw new NotImplementedException();
        }
    }
}
