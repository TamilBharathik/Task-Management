using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class Task
    {
        [Key]
        public Guid TaskId { get; set; }
        public string Title {  get; set; }  
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public string Attachment { get; set; }

 
    }
}
