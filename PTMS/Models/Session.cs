using System;
using System.ComponentModel.DataAnnotations;

namespace PTMS.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TrainerId { get; set; }
        public DateTime SessionDate { get; set; }
    }
}

