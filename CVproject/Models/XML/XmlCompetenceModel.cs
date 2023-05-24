using System.ComponentModel.DataAnnotations;

namespace CVproject.Models.XML
{
    public class XmlCompetenceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CvId { get; set; }
    }
}
