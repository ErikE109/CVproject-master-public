using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CVproject.Models
{
    public class ProjectMember
    {
        public string PersonId { get; set; }
        public int ProjectId { get; set; }

        [XmlIgnore]

        [ForeignKey(nameof(PersonId))]
        public virtual Person? Person { get; set; }

        [XmlIgnore]
        [ForeignKey(nameof(ProjectId))]
        public virtual Project? Project { get; set; }
    }
}
