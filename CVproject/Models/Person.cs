using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace CVproject.Models
{
    public class Person : IdentityUser
    {
        public string Name { get; set; }
        public string? Picture { get; set; }
        public int? CvId { get; set; }

        public bool IsPrivate { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public string? Github { get; set; }

        public virtual IEnumerable<Project>? Projects { get; set; }
  
        public virtual IEnumerable<Message>? ReceivedMessages { get; set; }
        public virtual IEnumerable<ProjectMember>? ProjectMembers {get;set;}


        [ForeignKey(nameof(CvId))]
        public virtual CV? CV { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }


    }
}
