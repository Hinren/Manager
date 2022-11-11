using System.Xml.Serialization;

namespace Common.Models.Snippet
{
    [XmlRoot(ElementName = "Header")]
    public class Header
    {

        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Author")]
        public string Author { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "Shortcut")]
        public string Shortcut { get; set; }
    }
}
