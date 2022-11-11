using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.Models.Snippet
{
	[XmlRoot(ElementName = "Literal")]
	public class Literal
	{

		[XmlElement(ElementName = "ID")]
		public string ID { get; set; }

		[XmlElement(ElementName = "ToolTip")]
		public string ToolTip { get; set; }

		[XmlElement(ElementName = "Default")]
		public string Default { get; set; }
	}
}
