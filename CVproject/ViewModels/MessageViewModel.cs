using CVproject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVproject.ViewModels
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = "Please enter a sender name.")]
        [StringLength(255)]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "Please enter a receiver name.")]
        [StringLength(255)]
        public string ReceiverName { get; set; }

        [Required(ErrorMessage = "Please enter receiver id.")]
        [StringLength(255)]
        public string ReceiverId { get; set; }

        [Required(ErrorMessage = "Please enter a heading.")]
        [StringLength(255)]
        public string Heading { get; set; }

        [Required(ErrorMessage = "Please enter a text.")]
        [StringLength(255)]
        public string Text { get; set; }


    }
}
