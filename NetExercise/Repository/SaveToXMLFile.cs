using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NetExercise.Models;

namespace NetExercise.Repository
{
    public class SaveToXMLFile : ISaveToFile
    {
        public void SaveFile(Text text, string dirPath)
        {
            string applicationPath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "Output");
            if(!Directory.Exists(applicationPath))
            {
                Directory.CreateDirectory(applicationPath);
            }
            dirPath = Path.Combine(applicationPath, dirPath);

            XmlSerializer xmlserializer = new XmlSerializer(typeof(Text));
            var xml = "";

            using (var stringWriter = new Utf8StringWriter())
            {
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    writer.WriteStartDocument(true);
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");

                    xmlserializer.Serialize(writer, text, ns);
                    xml = stringWriter.ToString();
                }
            }
            File.WriteAllText(dirPath + ".xml", xml);
        }

        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}