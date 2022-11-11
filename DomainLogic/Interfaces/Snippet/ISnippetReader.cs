using Common.Models.Snippet;

namespace DomainLogic.Interfaces.Snippet
{
    public interface ISnippetReader
    {
        public CodeSnippets ReadSnippet(string path);
        public List<CodeSnippets> ReadSnippets(string path);
    }
}
