using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace APP.Auth.Services
{
    public static class GenerateSecurityKey
    {
        /// <summary>
        ///     Метод шифрующий секретный ключ
        /// </summary>
        /// <returns> SecurityKey </returns>
        public static SecurityKey GetSecurityKey() => GetSecurityKey(key => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)));

        /// <summary>
        ///     Метод возвращающий секретный ключ.
        /// </summary>
        /// <param name="func"> lambda с стрингой на вход. </param>
        /// <returns> SecurityKey </returns>
        public static SecurityKey GetSecurityKey(Func<string, SecurityKey> func)
        {
            return func(AuthOptions.KEY);
        }
    }
}
