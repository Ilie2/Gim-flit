using System.Text.Json.Serialization;

namespace GymFit.Models
{
    public class Client : User
    {
        public string Name { get; set; }

        public string Last_name { get; set; }

        public string Sub { get; set; }

        public string Description { get; set; }

        [JsonIgnore] // Ignorăm serializarea proprietății Subscription
        public virtual Subscription? Subscription { get; set; }
    }
}
