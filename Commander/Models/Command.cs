using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    // Model: Class/Object Representation of a database table. Individual Classes can also be called Entities. 
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}