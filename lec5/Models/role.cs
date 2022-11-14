using System.Data;

namespace lec5.Models
{
    public class role
    {
        public int Id { get; set; } 
        public string RoleName { get; set; }

        public role()
        {
            Users = new HashSet<User>();
        }
        public ICollection<User> Users { get; set; }

    }
}
