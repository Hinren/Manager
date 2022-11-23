using System.Xml.Serialization;

namespace Common.Models.Snippet
{
    //[XmlRoot(ElementName = "CodeSnippets", Namespace = "http://main.com"), XmlType("CodeSnippets")]
    [XmlType("CodeSnippets")]
    public class CodeSnippets
    {
        [XmlElement(ElementName = "CodeSnippet")]
        public List<CodeSnippet> CodeSnippet { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}