using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace APP.Auth.Services
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        public const string KEY = "some_secret_key_like";   // ключ для шифрации
        public const int LIFETIME = 10; // время жизни токена - 10 минут
    }
}
