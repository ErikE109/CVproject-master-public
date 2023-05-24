using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace CVproject.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter an Employer.")]
        [StringLength(255)]
        public string Employer { get; set; }

        [Required(ErrorMessage = "Please enter a Title.")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a start year.")]
        [Range(1950, 2023, ErrorMessage = "Please enter a start year")]
        [Display(Name = "Start Year")]
        public int StartYear { get; set; }

        [Required(ErrorMessage = "Please enter an end year.")]
        [Range(1950, 2023, ErrorMessage = "Please enter an end year")]
        [Display(Name = "End Year")]
        public int EndYear { get; set; }
        public int CvId { get; set; }

        [ForeignKey(nameof(CvId))]
        public virtual CV? Cv { get; set; }

        public Experience(int id)
        {
            CvId = id;
        }
        
        public Experience () { }
    }
}
