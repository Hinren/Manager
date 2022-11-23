using System.Xml.Serialization;

namespace Common.Models.Snippet
{
	[XmlRoot(ElementName = "CodeSnippet")]
	//[XmlType("CodeSnippet")]
	public class CodeSnippet
	{
		[XmlElement(ElementName = "Header")]
		public Header Header { get; set; }

		[XmlElement(ElementName = "Snippet")]
		public Snippet Snippet { get; set; }

		[XmlAttribute(AttributeName = "Format")]
		public string Format { get; set; }

		[XmlText]
		public string Text { get; set; }
	}
}
