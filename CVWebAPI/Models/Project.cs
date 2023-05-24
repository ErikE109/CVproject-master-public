using System.ComponentModel.DataAnnotations.Schema;

namespace CVWebAPI.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string ProjectOwner { get; set; }

        [ForeignKey(nameof(ProjectOwner))]
        public virtual Person? Person { get; set; }

        public virtual IEnumerable<ProjectMember>? ProjectMembers { get; set; }


    }
}
