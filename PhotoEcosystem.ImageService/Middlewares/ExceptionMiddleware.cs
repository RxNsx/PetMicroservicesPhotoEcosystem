using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace PhotoEcosystem.ImageService.Middlewares
{
    /// <summary>
    /// Миддлвэйр для обработки исключений
    /// </summary>
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Обработка контекста запроса
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server Error",
                    Title = "Server Error",
                    Detail = $"{ex.Message}"
                };

                string json = JsonSerializer.Serialize(problem);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
