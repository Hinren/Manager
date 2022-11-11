using System.Xml.Serialization;

namespace Common.Models.Snippet
{
    [XmlRoot(ElementName = "CodeSnippets")]
    public class CodeSnippets
    {

        [XmlElement(ElementName = "CodeSnippet")]
        public CodeSnippet CodeSnippet { get; set; }
    }
}