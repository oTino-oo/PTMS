namespace PTMS.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string ClientId { get; set; } = "";

        public int TrainerId { get; set; }

        public int Age { get; set; }

        public double CurrentWeight { get; set; }

        public double TargetWeight { get; set; }

        public string Experience { get; set; } = "";

        public string Status { get; set; } = "Pending";
        public string PlanType { get; set; } = "Monthly";
    }
}