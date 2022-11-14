using Microsoft.Build.Framework;

namespace lec5.Models
{
    public class LoginViewModel
    {
        [Required]
        public string username {get;set;}

        [Required]
        public string password {get;set;}
    }
}
