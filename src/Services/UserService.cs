using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace jwt
{
    public class UserService
    {
        private readonly AppSettings _appSettings;
        private readonly TokenService _tokenService;

        public UserService(IOptions<AppSettings> appSettings, TokenService tokenService)
        {
            _appSettings = appSettings.Value;
            _tokenService = tokenService;
        }

        public User Authenticate(string username, string password)
        {
            //Authentication will go here
            return _tokenService.GetToken(_appSettings.Secret);
        }

        public User Authenticate()
        {
            //Authentication will go here
            return _tokenService.GetToken(_appSettings.Secret);
        }
    }
}