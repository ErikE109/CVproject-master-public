using System.ComponentModel;
using System.Xml.Serialization;

namespace CVproject.Models.XML
{
    [Serializable]
    public class XMLmodel
    {
        public string Name { get; set; }
        public string? Picture { get; set; }
        public int? CvId { get; set; }

        public bool IsPrivate { get; set; } = false;

        //[XmlIgnore]
        public virtual List<XmlProjectModel>? Projects { get; set; }
        //[XmlIgnore]
        public XmlCvModel CvModelXml { get; set; }


        public XMLmodel()
        {

        }
    }
}
