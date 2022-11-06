using System.ComponentModel.DataAnnotations;
namespace SigmaTask.Models
{
    public class Candidate
    {
        [Key]
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string TimeInterval { get; set; }
        public string GitHub { get; set; }
        public string Linkedin { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
