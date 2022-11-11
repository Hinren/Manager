namespace DomainLogic.Interfaces.Snippet
{
    public interface ISnippetUploader
    {
        public void UploadSnippetToVisualStudioSetting(string path);
        public void UploadSnippetsToVisualStudioSetting(string path);
    }
}
