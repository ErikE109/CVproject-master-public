using System.Xml.Serialization;

namespace CVproject.Models.XML
{
    public class SerializerForXml
    {
        
        public void Serialize(XMLmodel xmlModel)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(XMLmodel));

                using (FileStream filestream = new FileStream("PersonInfo.xml", FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(filestream, xmlModel);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exaption", e);
            }
        }
        
    }
}
