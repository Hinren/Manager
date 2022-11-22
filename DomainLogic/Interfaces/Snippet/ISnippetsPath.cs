namespace DomainLogic.Interfaces.Snippet
{
    public interface ISnippetsPath
    {
        public string CsharpDestinationPath();
        public string CSSDestinationPath();
        public string HTMLDestinationPath();
        public string JavaScriptDestinationPath();
        public string TypeScriptDestinationPath();
        public string XAMLDestinationPath();
        public string CsharpLocalAppPath();
        public string CSSLocalAppPath();
        public string HTMLLocalAppPath();
        public string JavaScriptLocalAppPath();
        public string TypeScriptLocalAppPath();
        public string XAMLLocalAppPath();
        public string VisualStudioFolderName();
    }
}
