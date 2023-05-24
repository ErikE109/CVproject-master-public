using System.ComponentModel.DataAnnotations.Schema;

namespace CVWebAPI.Models
{
    public class ProjectMember
    {
        public string PersonId { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public virtual Person? Person { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project? Project { get; set; }
    }
}
