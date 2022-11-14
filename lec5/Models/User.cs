using System.ComponentModel.DataAnnotations.Schema;

namespace lec5.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        [NotMapped]
        public string cpassword { get; set; }

        public User() 
        {
            roles = new HashSet<role>();
        }
        public ICollection<role> roles { get; set; }
    }
}
