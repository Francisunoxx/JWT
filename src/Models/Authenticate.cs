using System.ComponentModel.DataAnnotations;

namespace jwt
{
    public class Authenticate
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}