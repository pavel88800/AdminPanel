using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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
        public static IServiceCollection AddSwaggerAppGen(this IServiceCollection services)
        {
            var swagger = services
                .AddMvc(options => options.EnableEndpointRouting = false).Services
                .AddSwaggerGen(c => c.SwaggerDoc(SwaggerInfo.VersionName, SwaggerInfo.Api));


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
    }
}