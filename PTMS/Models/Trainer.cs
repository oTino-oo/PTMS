using System.ComponentModel.DataAnnotations;
namespace PTMS.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Specialisation { get; set; }

        public User User { get; set; }
    }
}