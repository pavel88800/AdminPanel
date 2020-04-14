using APP.Common.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace APProject.Middleware
{
    /// <summary>
    ///     Экстеншны для использования middleware.
    /// </summary>
    public static class AppMiddlewareExtension
    {
        /// <summary>
        ///     Регистрация middleware для обработки ошибок при выполнении запроса.
        /// </summary>
        /// <param name="builder"> Билдер приложения. </param>
        public static IApplicationBuilder UseHttpStatusCodeExceptionMiddleware(this IApplicationBuilder builder) =>
            builder.UseMiddleware<ExceptionMiddleware>();
    }
}