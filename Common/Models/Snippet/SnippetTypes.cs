using System.Xml.Serialization;

namespace Common.Models.Snippet
{
    [XmlRoot(ElementName = "SnippetTypes")]
    public class SnippetTypes
    {

        [XmlElement(ElementName = "SnippetType")]
        public string SnippetType { get; set; }
    }
}
