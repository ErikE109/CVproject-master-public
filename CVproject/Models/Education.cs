using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVproject.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "University is required")]
        [StringLength(255)]
        public string University { get; set; }

        [Required(ErrorMessage = "Please enter a start year.")]
        [Range(1950, 2023, ErrorMessage = "Please enter a start year")]
        [Display(Name = "Start Year")]
        public int StartYear { get; set; }

        [Required(ErrorMessage = "Please enter an end year.")]
        [Range(1950, 2027, ErrorMessage = "Please enter an end year")]
        [Display(Name = "End Year")]
        public int EndYear { get; set; }
        [Required(ErrorMessage = "Orientation is required")]
        [StringLength(255)]
        public string Orientation { get; set; }
        public int CvId { get; set; }

        [ForeignKey(nameof(CvId))]
        public virtual CV? Cv { get; set; }

        public Education(int id)
        {
            CvId = id;
        }

        public Education() { }
    }
}
