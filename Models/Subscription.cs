using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization; // Adăugați această directivă

namespace GymFit.Models
{
    public class Subscription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        [JsonIgnore] // Ignorăm serializarea proprietății Courses
        public virtual List<Course> Courses { get; set; }
        public string Duration { get; set; }
    }
}
