using System;
using System.ComponentModel.DataAnnotations;

namespace PTMS.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int TrainerId { get; set; }

        [Required]
        public DateTime SessionDate { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = "Available";
    }
}