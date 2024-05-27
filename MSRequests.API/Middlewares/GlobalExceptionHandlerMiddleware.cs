
using MSRequests.Domain.DTOs;
using System.Data;
using System.Net;
using System.Text.Json;

namespace MSRequests.API.Middlewares;

public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }

        catch (Exception ex)
        {
            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var logFilePath = Path.Combine(documentsFolder, "errorlog.txt");

            File.AppendAllText(logFilePath, $"ex : {ex.Message}{Environment.NewLine}" +
                $"inner ex : {ex.InnerException ?? new Exception()}{Environment.NewLine}" +
                $"StackTrace : {ex.StackTrace}{Environment.NewLine}" +
                $"Date : {DateTime.Now}{Environment.NewLine}{Environment.NewLine}");

            HttpStatusCode code;
            string message = string.Empty;
            switch (ex)
            {
                case KeyNotFoundException or FileNotFoundException:
                    code = HttpStatusCode.NotFound;
                    message = "Item is not found!";
                    break;

                case DuplicateNameException:
                    code = HttpStatusCode.Conflict;
                    message = "Item already exists!";
                    break;

                case UnauthorizedAccessException:
                    code = HttpStatusCode.Forbidden;
                    message = "You are not authorized to do this action!";
                    break;

                case ArgumentException:
                    code = HttpStatusCode.BadRequest;
                    message = "bad request!";
                    break;

                default:
                    code = HttpStatusCode.InternalServerError;
                    message = "Internal server error!";
                    break;
            }

            context.Response.StatusCode = (int)code;

            var result = new Response<string?>()
            {
                Success = false,
                Message = message,
                Data = null
            };

            string json = JsonSerializer.Serialize(result);

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);
        }
    }
}