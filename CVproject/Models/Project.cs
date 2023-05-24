using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CVproject.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string ProjectOwner { get; set; }

        [XmlIgnore]
        [ForeignKey(nameof(ProjectOwner))]
        public virtual Person? Person { get; set; }

        [XmlIgnore]
        public virtual IEnumerable<ProjectMember>? ProjectMembers { get; set; }


    }
}
