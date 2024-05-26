using System.Text.Json.Serialization;
namespace GymFit.Models

{
    public class Trainer : User
    {
        internal int id;

        public string Name { get; set; }
        public string Last_name { get; set; }   

        public int Age { get; set; }

        public int Experience { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }
    }
}