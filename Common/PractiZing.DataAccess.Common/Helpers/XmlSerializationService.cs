using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace PractiZing.DataAccess.Common.Helpers
{
    public class XmlSerializationService<T> where T : class
    {
        public byte[] Serialize(T obj)
        {
            var formatter = new XmlSerializer(typeof(T));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            //using (var stream = new MemoryStream())
            //{
            //    formatter.Serialize(stream, obj, ns);
            //    return stream.ToArray();
            //}
            using (var stream = new MemoryStream())
            {
                using (var xmlTextWriter = new MyXmlTextWriter(stream) { Formatting = Formatting.Indented })
                {
                    formatter.Serialize(xmlTextWriter, obj, ns);
                    return stream.ToArray();
                }
            }
        }
    }

    public class MyXmlTextWriter : XmlTextWriter
    {
        public MyXmlTextWriter(Stream stream) : base(stream, Encoding.UTF8)
        {

        }

        public override void WriteEndElement()
        {
            base.WriteFullEndElement();
        }
    }
}
