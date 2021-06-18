using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Stocks.save_to_xml
{
    [XmlRoot("_Company")]
    public class _Company
    {
        [XmlElement("Link")]
        public List<string> Link;
    }

    public class SaveCompaniesList
    {
        public void WriteXML(List<string> link)
        {
            _Company overview = new _Company();
            overview.Link = link;
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(_Company));

            string path = @"C:\Users\pkubo\OneDrive\Desktop\stocks excel\Stocks\xml\companiesList.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, overview);
            file.Close();
        }
        public void Read(ref List<string> ret)
        {
            string path = @"C:\Users\pkubo\OneDrive\Desktop\stocks excel\Stocks\xml\companiesList.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(_Company));
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                ret = ((_Company)serializer.Deserialize(fileStream) ).Link;
            }
        }
    }
}
