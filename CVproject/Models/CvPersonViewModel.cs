using CVproject.Controllers;

namespace CVproject.Models
{
    public class CvPersonViewModel
    {
        public Person person { get; set; }
        public CV cv { get; set; }

        public Education education { get; set; }

        public Experience experience { get; set; } 

        public List<Competence> competences { get; set; }  = new List<Competence>();
        

        public CvPersonViewModel ()
        {

        }

    }
}
