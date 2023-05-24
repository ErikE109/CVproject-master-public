using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVproject.Models
{
    public class CvViewModel
    {
        public List<Competence> Competences { get; set; }
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }

        public CvViewModel ()
        {
            List<Competence> Competences = new List<Competence> ();
            List<Education> Educations = new List<Education> ();
            List<Experience> Experiences = new List<Experience> ();

        }
        
    }
}
