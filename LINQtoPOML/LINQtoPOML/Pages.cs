using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LINQtoPOML
{
    [Serializable]
    [XmlRoot("Pages")]
    public class Pages
    {
        [XmlAttribute("group")]
        public string Name { get; set; }

        [XmlElement("Page")]
        public List<Page> ListOfPages { get; set; }
    }
}