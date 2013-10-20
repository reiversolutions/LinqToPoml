using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace LINQtoPOML.Internal.Parsers
{
    internal class PageObjectParser : AbstractPageObjectParser
    {
        internal override Pages ParseFile(FileInfo file)
        {
            if (file.Exists && file.Extension == ".poml")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pages));

                using (StreamReader reader = new StreamReader(file.FullName))
                {
                    Pages data = null;

                    // Convert .poml file to poml object
                    data = (Pages)serializer.Deserialize(reader);

                    return data;
                }
            }
            
            return null;
        }

        internal override bool SaveObject(FileInfo file, Pages data)
        {
            if (file.Extension == ".poml")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pages));
                using (StreamWriter writer = new StreamWriter(file.FullName))
                {
                    using (XmlWriter xwriter = XmlWriter.Create(writer, new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true }))
                    {
                        // Remove namespaces
                        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                        namespaces.Add("", "");

                        // Convert poml object to .poml file
                        serializer.Serialize(xwriter, data, namespaces);

                        return true;
                    }
                }
            }

            return false;
        }
    }
}