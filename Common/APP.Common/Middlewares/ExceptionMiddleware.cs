namespace APP.Common.Middlewares
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class ExceptionMiddleware
    {
        /// <summary>
        ///     Ссылка на делегат запроса
        /// </summary>
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await WriteResponse(context, e.Message);
            }
        }

        /// <summary>
        ///     Записывает ответ указанного контекста.
        /// </summary>
        /// <param name="context">Контекст запроса.</param>
        /// <param name="statusCode">Код ответа.</param>
        /// <param name="message">Сообщение ответа.</param>
        private static async Task WriteResponse(HttpContext context,
            string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            context.Response.StatusCode = (int) statusCode;
            context.Response.ContentType = @"text/plain; charset=utf-8";
            await context.Response.WriteAsync(message);
        }
    }
}