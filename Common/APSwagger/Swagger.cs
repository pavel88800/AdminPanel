using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace APSwagger
{
    public static class Swagger
    {
        /// <summary>
        ///     Версия, название и описание API swagger.
        /// </summary>
        private static readonly SwaggerInfo SwaggerInfo = new SwaggerInfo();

        /// <summary>
        ///     Добавить генератор Swagger.
        /// </summary>
        /// <param name="services"> Коллекция сервисов. </param>
        /// <param name="authType"> Тип аутентификации. </param>
       
        public static IServiceCollection AddSwaggerAppGen(this IServiceCollection services, AuthType authType)
        {
            var swagger = services
                .AddMvc(options => options.EnableEndpointRouting = false).Services
                .AddSwaggerGen(c => c.SwaggerDoc(SwaggerInfo.VersionName, SwaggerInfo.Api));

            switch (authType)
            {
                case AuthType.None:
                    break;
                case AuthType.Bearer:
                    swagger.AddSwaggerAppBearerAuth();
                    break;
            }

            return swagger;
        }

        /// <summary>
        ///     Использовать Swagger совместно с GUI.
        /// </summary>
        /// <param name="app"> Построитель приложения. </param>
        /// <param name="apiName"> Наименование API. </param>
        public static IApplicationBuilder UseSwaggerApp(this IApplicationBuilder app, string apiName)
        {
            SwaggerInfo.ApiName = apiName;
            return app.UseSwaggerApp();
        }

        /// <summary>
        ///     Использовать Swagger совместно с GUI.
        /// </summary>
        /// <param name="app"> Построитель приложения. </param>
        public static IApplicationBuilder UseSwaggerApp(this IApplicationBuilder app)
        {
            return app
                .UseSwagger()
                .UseSwaggerUI(options => options.SwaggerEndpoint(SwaggerInfo.ApiUrl, SwaggerInfo.ApiName));
        }

        /// <summary>
        ///     Добавляет "Bearer authentication" для swagger.     
        /// </summary>
        /// <param name="services"> Коллекция сервисов. </param>
        /// <remarks>*Ссылка на OpenApiSecurityRequirement с пояснением, зачем нужен пустой List<string>*
        ///     https://github.com/microsoft/OpenAPI.NET/blob/master/src/Microsoft.OpenApi/Models/OpenApiSecurityRequirement.cs
        /// </remarks>
        private static IServiceCollection AddSwaggerAppBearerAuth(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please enter into field the word 'Bearer' following by space and JWT",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme }
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}