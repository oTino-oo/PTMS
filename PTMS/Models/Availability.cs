using System;
using System.ComponentModel.DataAnnotations;

namespace PTMS.Models
{
    public class Availability
    {
        public int Id { get; set; }

        [Required]
        public int TrainerId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public Trainer Trainer { get; set; }
    }
}