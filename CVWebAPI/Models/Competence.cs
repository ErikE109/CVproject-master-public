using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVWebAPI.Models
{
    public class Competence
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Competence")]
        public string Name { get; set; }

        public int CvId { get; set; }

        [ForeignKey(nameof(CvId))]
        public virtual CV Cv { get; set; }
    }
}
