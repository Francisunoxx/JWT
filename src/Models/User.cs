using System;

namespace jwt
{
    public class User
    {
        public string Token { get; set; }
        public DateTime? Expiry { get; set; }
    }
}