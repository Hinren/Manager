using System.Xml;
using System.Xml.Serialization;

namespace Common.Models.Snippet
{
    [XmlRoot(ElementName = "Code")]
    public class Code
    {
        [XmlAttribute(AttributeName = "Language")]
        public string Language { get; set; }

        [XmlIgnore]
        public string Content { get; set; }

        [XmlText]
        public XmlNode[] CDataContent
        {
            get
            {
                var dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(Content) };
            }
            set
            {
                if (value == null)
                {
                    Content = null;
                    return;
                }

                if (value.Length != 1)
                {
                    throw new InvalidOperationException(
                        String.Format(
                            "Invalid array length {0}", value.Length));
                }

                Content = value[0].Value;
            }
        }
    }
}
