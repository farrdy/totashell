using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace Services.Utility
{
    /// <summary>
    /// Utility class used to perform XSLT transformation on a serializable object
    /// </summary>
    public static class XsltTransformer
    {
        static XmlReader WriteToReader(Action<XmlWriter> write)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
                write(writer);
            return doc.CreateReader();
        }

        static XmlReader Serialize<T>(T serializableObj)
        {
            var xmls = new XmlSerializer(typeof(T));
            return WriteToReader(writer => xmls.Serialize(writer, serializableObj));
        }

        static XmlReader Transform(XmlReader serialized, string xsltPath)
        {
            var transform = new XslCompiledTransform();
            transform.Load(xsltPath);
            return WriteToReader(writer => transform.Transform(serialized, writer));
        }

        public static XmlDocument Render<T>(T serializableObj, string xsltPath)
        {
            var document = new XmlDocument();
            document.Load(Transform(Serialize(serializableObj), xsltPath));
            return document;
        }
    }
}