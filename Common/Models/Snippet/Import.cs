using System.Xml.Serialization;

namespace Common.Models.Snippet
{
    [XmlRoot(ElementName = "Import")]
    public class Import
    {

        [XmlElement(ElementName = "Namespace")]
        public string Namespace { get; set; }
    }
}
