using Common.Models.Snippet;
using DomainLogic.Interfaces.Snippet;

namespace DomainLogic.Snippet
{
    internal class SnippetReader : ISnippetReader
    {
        private readonly ISnippetsPath _snippetPath;

        public SnippetReader()
        {
            _snippetPath = new SnippetsLocalizations();
        }

        public CodeSnippets ReadSnippet(string path)
        {
            throw new NotImplementedException();
        }

        public CodeSnippets ReadSnippet()
        {
            throw new NotImplementedException();
        }

        public List<CodeSnippets> ReadSnippets(string path)
        {
            throw new NotImplementedException();
        }

        public List<CodeSnippets> ReadSnippets()
        {
            throw new NotImplementedException();
        }
    }
}
