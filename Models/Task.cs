using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class Task
    {
        // Id
        [Key] //primary key
        public int Id { get; set; }

        // Date and Time of expiry
        [Required] //not null
        public DateTime ExpiryDateTime { get; set; }

        // Title
        [Required]//not null
        [MaxLength(100)] //max lenght of title
        public string Title { get; set; }

        // description
        [MaxLength(500)] // max lenght of description
        public string Description { get; set; }

        // complete in percent range 
        [Range(0, 100)]
        public int PercentComplete { get; set; }
    }
}
