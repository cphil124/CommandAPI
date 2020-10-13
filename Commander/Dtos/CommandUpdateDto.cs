using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{

    //TODO: Create CommandUpdateDto as Clone of CommandCreateDto and keep them in sync
    public class CommandUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}