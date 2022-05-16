using Microsoft.AspNetCore.Http;
using PDITWA.Exceptions;
using System.Threading.Tasks;

namespace PDITWA.Middlwares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next; //nastepny middleware

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ProductsAlreadyExistsException)
            {
                context.Response.StatusCode = StatusCodes.Status402PaymentRequired;
            }
            catch(System.Exception)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}
