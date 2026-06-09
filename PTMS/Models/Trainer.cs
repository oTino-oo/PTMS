using System.ComponentModel.DataAnnotations;
namespace PTMS.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
    }
}