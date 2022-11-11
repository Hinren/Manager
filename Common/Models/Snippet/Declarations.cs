using System.Xml.Serialization;

namespace Common.Models.Snippet
{
    [XmlRoot(ElementName = "Declarations")]
    public class Declarations
    {

        [XmlElement(ElementName = "Literal")]
        public Literal Literal { get; set; }
    }

}
