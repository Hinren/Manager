using System.Xml.Serialization;

namespace Common.Models.Snippet
{
    [XmlRoot(ElementName = "Code")]
    public class Code
    {

        [XmlAttribute(AttributeName = "Language")]
        public string Language { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
