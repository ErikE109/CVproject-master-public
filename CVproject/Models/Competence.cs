using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVproject.Models
{
    public class Competence
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Competence")]

        [Required(ErrorMessage = "Please enter a Competence.")]
        [StringLength(255)]
        public string Name { get; set; }

        public int CvId { get; set; }

        [ForeignKey(nameof(CvId))]
        public virtual CV Cv { get; set; }

        public Competence(int id)
        {
            CvId = id;
        }

        public Competence() { }
    }
}
