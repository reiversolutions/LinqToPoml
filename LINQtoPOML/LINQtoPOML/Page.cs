using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LINQtoPOML
{
    [Serializable]
    public class Page
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("Element")]
        public List<PageElement> ListOfElements { get; set; }
    }
}