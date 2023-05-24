using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace CVWebAPI.Models
{
    [Table("AspNetUsers")]
    public class Person : IdentityUser
    {
        public string Name { get; set; }
        public string Picture { get; set; } = ".jpeg";
        public int? CvId { get; set; }

        public bool IsPrivate { get; set; } = false;

        public virtual IEnumerable<Project>? Projects { get; set; }
        
        public virtual IEnumerable<Message>? ReceivedMessages { get; set; } = new List<Message>();
        public virtual IEnumerable<ProjectMember>? ProjectMembers {get;set;}
        

        [ForeignKey(nameof(CvId))]
        public virtual CV? CV { get; set; }

        
    }
}
