using Common.Models.Snippet;
using DomainLogic.Interfaces.Snippet;

namespace DomainLogic.Snippet
{
    internal class SnippetSaver : ISnippetSaver
    {
        public CodeSnippets SaveSnippet(CodeSnippets snippet, string path)
        {
            throw new NotImplementedException();
        }

        public CodeSnippets SaveSnippets(List<CodeSnippets> snippets, string path)
        {
            throw new NotImplementedException();
        }
    }
}
