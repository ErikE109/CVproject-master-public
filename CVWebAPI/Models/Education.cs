using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVWebAPI.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        public string University { get; set; }
        [Display(Name = "Start Year")]
        public int StartYear { get; set; }
        [Display(Name = "End Year")]
        public int EndYear { get; set; }
        public string Orientation { get; set; }
        public int CvId { get; set; }

        [ForeignKey(nameof(CvId))]
        public virtual CV Cv { get; set; }

    }
}
