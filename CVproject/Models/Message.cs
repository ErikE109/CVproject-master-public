using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CVproject.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string ReceiverId { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }

        public bool IsRead { get; set; } = false;

        [XmlIgnore]
        [ForeignKey(nameof(ReceiverId))]
        public virtual Person? Receiver { get; set; }

    }
}
