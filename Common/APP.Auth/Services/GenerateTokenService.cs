using Microsoft.EntityFrameworkCore;

namespace APP.Auth.Services
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using APP.Auth.Interfaces;
    using APP.DB;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    ///     Сервис по работе с токеном.
    /// </summary>
    public class GenerateTokenService : IGenerateTokenService
    {
        private readonly PanelContext _context;

        public GenerateTokenService(PanelContext context)
        {
            _context = context;
        }

        ///<inheritdoc />
        public object GetToken(string login, string password)
        {
            var identity = GetIdentity(login, password);
            if (identity == null) return new {errorText = "Invalid username or password."};

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                AuthOptions.ISSUER,
                AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(GenerateSecurityKey.GetSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return response;
        }

        /// <summary>
        ///     Получить личность.
        /// </summary>
        /// <param name="login">логин.</param>
        /// <param name="password">пароль.</param>
        /// <returns></returns>
        private ClaimsIdentity GetIdentity(string login, string password)
        {
            var person = _context.Users.Include(r=>r.Role).FirstOrDefault(x => x.Login == login && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email)
                };

                var claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}