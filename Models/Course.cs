using System.ComponentModel.DataAnnotations.Schema;

namespace GymFit.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public virtual Trainer Trainer { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }
    }
}