using System.ComponentModel.DataAnnotations.Schema;

namespace GymFit.Models
{
    public class Subscription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } 
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public virtual List<Course> Courses { get; set; }

        public DateTime StartDate { get; set; }

        public string Duration { get; set; }
    }
}