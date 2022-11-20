using Common.Models.Snippet;

namespace DomainLogic.Interfaces.Snippet
{
    public interface ISnippetSaver
    {
        public void SaveSnippetOnLocalPath(CodeSnippets snippet);
        public void SaveSnippetsOnLocalPath(List<CodeSnippets> snippets);
        public void SaveSnippetsOnVisualStudioPath();
    }
}
