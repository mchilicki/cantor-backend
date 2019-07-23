using Chilicki.Cantor.Application.DTOs.Errors;
using Chilicki.Cantor.Domain.Helpers.Exceptions.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Chilicki.Cantor.WebAPI.Controllers.Base
{
    public class ErrorMiddlewareHandler
    {
        private readonly RequestDelegate next;
        public ErrorMiddlewareHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            if (exception is UnathorizedException) code = HttpStatusCode.Unauthorized;
            else if (exception is BadRequestException) code = HttpStatusCode.BadRequest;

            var errorDto = new ErrorDto()
            {
                Error = exception.Message
            };
            var result = JsonConvert.SerializeObject(errorDto);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
