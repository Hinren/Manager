using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
