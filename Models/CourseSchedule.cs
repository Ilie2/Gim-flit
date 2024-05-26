using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace GymFit.Models
{
    public class CourseSchedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public virtual Course ScheduledCourse { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual List<Client> Clients { get; set; }

        public int ClientNo { get; set; }

        [JsonIgnore] // Ignorăm serializarea proprietății Subscription
        public virtual Subscription? Subscription { get; set; }
    }
}
