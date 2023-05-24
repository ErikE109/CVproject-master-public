using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CVWebAPI.Models
{
    public class CV
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfViews { get; set; } = 0;
        public virtual IEnumerable<Competence>? Competences { get; set; }
        public virtual IEnumerable<Education>? Educations { get; set; }
        public virtual IEnumerable<Experience>? Experiences { get; set; }
        public virtual Person? Person { get; set; }


    }
}
