using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LINQtoPOML
{
    [Serializable]
    public class PageElement
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("locator")]
        public string Locator { get; set; }

        [XmlAttribute("selector")]
        public string Selector { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}