using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace APP.Auth.Services
{
    public static class RegistrationOnStartUp
    {
        public static IServiceCollection AddJwtBearer(this IServiceCollection service, bool httpsMetadata, bool showPII)
        {
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options =>
                    {
                        options.RequireHttpsMetadata = httpsMetadata;
                        options.TokenValidationParameters = TokenParametersBuilder.GetTokenParameters();
                        options.SaveToken = true;
                    });
            return service;
        }
    }
}
