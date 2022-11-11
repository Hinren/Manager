using Common.Models.Snippet;

namespace DomainLogic.Interfaces.Snippet
{
    public interface ISnippetSaver
    {
        public CodeSnippets SaveSnippet(CodeSnippets snippet, string path);
        public CodeSnippets SaveSnippets(List<CodeSnippets> snippets, string path);
    }
}
