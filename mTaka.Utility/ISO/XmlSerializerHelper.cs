using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace mTaka.Utility.ISO20022
{
    public static class XmlSerializerHelper
    {
        public static string FilteredXml(string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNode node = xmlDoc.DocumentElement?.GetElementsByTagName("Document")[0];
            return node?.OuterXml;
        }
    }
}