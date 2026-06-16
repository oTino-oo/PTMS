namespace PTMS.Models
{
    public class UserApproval
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public bool IsApproved { get; set; } = false;

        public string Role { get; set; }
    }
}