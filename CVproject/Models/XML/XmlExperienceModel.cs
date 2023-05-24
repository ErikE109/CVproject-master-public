using System.ComponentModel.DataAnnotations;

namespace CVproject.Models.XML
{
    public class XmlExperienceModel
    {
        public int Id { get; set; }

        public string Employer { get; set; }

        public string Title { get; set; }

        public int StartYear { get; set; }

        public int EndYear { get; set; }
        public int CvId { get; set; }
    }
}
