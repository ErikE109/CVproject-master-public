namespace CVproject.Models.XML
{
    public class XmlCvModel
    {
        public int Id { get; set; }
        public int NumberOfViews { get; set; }
        public List<XmlCompetenceModel>? Competences { get; set; }
        public List<XmlEducationModel>? Educations { get; set; }
        public List<XmlExperienceModel>? Experiences { get; set; }
     
    }
}
