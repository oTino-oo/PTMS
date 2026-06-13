namespace PTMS.Models
{
    public class Session
    {
        public int Id { get; set; }

        public int TrainerId { get; set; }

        public string ClientId { get; set; }   

        public DateTime SessionDate { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; } = "Scheduled";
    }
}