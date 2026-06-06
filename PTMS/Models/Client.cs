using System.ComponentModel.DataAnnotations;

namespace PTMS.Models
{
    public class Client
    {
        public int id { get; set; }

        [Required]
        public int UserId { get; set; }

        public string FitnessGoal { get; set; }

        public User User { get; set; }
    }
}