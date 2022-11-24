using Common.Models.Snippet;

namespace DomainLogic.Interfaces.Snippet
{
    public interface ISnippetSaver
    {
        public void SaveSnippetOnLocalPath(string path);
        public void SaveSnippetsOnLocalPath();
        public void SaveSnippetsOnLocalPath(string path);
        public void SaveSnippetsOnVisualStudioPath();
    }
}
