using System.ComponentModel.DataAnnotations;

namespace CVproject.ViewModels
{
    public class ProjectViewModel
    {
        [Required(ErrorMessage = "Please enter a project name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
