using System.ComponentModel.DataAnnotations;

namespace CVproject.Models.XML
{
    public class XmlEducationModel
    {
        public int Id { get; set; }
        public string University { get; set; }

        public int StartYear { get; set; }

        public int EndYear { get; set; }
        public string Orientation { get; set; }
        public int CvId { get; set; }
    }
}
