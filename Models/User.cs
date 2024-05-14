using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GymFit.Models
{
    public enum Role { Admin, Client }

    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Number_of_phone{ get; set; }  


        public Role Role { get; set; }


    }
}
