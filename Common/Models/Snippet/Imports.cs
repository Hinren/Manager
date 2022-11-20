using System.Xml.Serialization;

namespace Common.Models.Snippet
{
    [XmlRoot(ElementName = "Imports")]
    public class Imports
    {

        [XmlElement(ElementName = "Import")]
        public List<Import> Import { get; set; }
    }
}
