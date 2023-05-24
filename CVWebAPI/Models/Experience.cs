using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace CVWebAPI.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public string Employer { get; set; }
        public string Title { get; set; }
        
        [Display(Name = "Start Year")]
        public int StartYear { get; set; }
        [Display(Name = "End Year")]
        public int EndYear { get; set; }
        public int CvId { get; set; }

        [ForeignKey(nameof(CvId))]
        public virtual CV Cv { get; set; }
    }
}
