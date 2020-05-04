using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace APP.Auth.Services
{
    public class TokenParametersBuilder
    {

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public TokenParametersBuilder()
        {
            Value = new TokenValidationParameters();
        }

        /// <summary>
        /// Результат строения.
        /// </summary>
        public TokenValidationParameters Value { get; }

        /// <summary>
        ///     Указать, будет ли валидироваться издатель при валидации токена.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns></returns>
        public TokenParametersBuilder IsValidateIssuer(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Value.ValidateIssuer = true;
                Value.ValidIssuer = value;
            }
            else
            {
                Value.ValidateIssuer = false;
            }

            return this;
        }

        /// <summary>
        /// Указывает, будет ли валидация ключа безопасности.
        /// </summary>
        /// <param name="value"> Значение. </param>
        /// <returns> Построитель. </returns>
        /// <remarks> По умолчанию true. </remarks>
        public TokenParametersBuilder IsValidateIssuerSigningKey(SecurityKey value)
        {
            if (value != null)
            {
                Value.ValidateIssuerSigningKey = true;
                Value.IssuerSigningKey = value;
            }
            else
            {
                Value.ValidateIssuerSigningKey = false;
            }

            return this;
        }

        /// <summary>
        /// Указывает, будет ли валидироваться время существования.
        /// </summary>
        /// <param name="value"> Значение. </param>
        /// <returns> Построитель. </returns>
        /// <remarks> По умолчанию true. </remarks>
        public TokenParametersBuilder IsValidateLifetime(bool value = true)
        {
            Value.ValidateLifetime = value;

            return this;
        }

        /// <summary>
        /// Указывает, будет ли валидироваться потребитель токена.
        /// </summary>
        /// <param name="value"> Значение. </param>
        /// <returns> Построитель. </returns>
        /// <remarks> По умолчанию true. </remarks>
        public TokenParametersBuilder IsValidateAudience(string value = "")
        {
            if (!string.IsNullOrEmpty(value))
            {
                Value.ValidAudience = value;
                Value.ValidateAudience = true;
            }
            else
            {
                Value.ValidateAudience = false;
            }

            return this;
        }

        /// <summary>
        ///     Получить параметры токена
        /// </summary>
        /// <returns> TokenValidationParameters. </returns>
        public static TokenValidationParameters GetTokenParameters()
        {
            var issuer = AuthOptions.ISSUER;

            return new TokenParametersBuilder()
                .IsValidateIssuer(issuer)
                .IsValidateAudience()
                .IsValidateLifetime()
                .IsValidateIssuerSigningKey(GenerateSecurityKey.GetSecurityKey())
                .Value;
        }
    }
}
