using System;
using System.ComponentModel.DataAnnotations;

namespace PTMS.Models
{
    public class Progress
    {
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int TrainerId { get; set; }

        public string Notes { get; set; }

        public double Weight { get; set; }

        public DateTime DateRecorded { get; set; }

        public Client Client { get; set; }
        public Trainer Trainer { get; set; }
    }
}