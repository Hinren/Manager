using System.Xml.Serialization;

namespace Common.Models.Snippet
{
	[XmlRoot(ElementName = "CodeSnippet")]
	public class CodeSnippet
	{

		[XmlElement(ElementName = "Header")]
		public Header Header { get; set; }

		[XmlElement(ElementName = "Snippet")]
		public Snippet Snippet { get; set; }

		[XmlAttribute(AttributeName = "Format")]
		public DateTime Format { get; set; }

		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }

		[XmlText]
		public string Text { get; set; }
	}
}
