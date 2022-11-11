﻿using System.Xml.Serialization;

namespace Common.Models.Snippet
{
    [XmlRoot(ElementName = "Snippet")]
    public class Snippet
    {

        [XmlElement(ElementName = "Declarations")]
        public Declarations Declarations { get; set; }

        [XmlElement(ElementName = "Code")]
        public Code Code { get; set; }
    }
}
