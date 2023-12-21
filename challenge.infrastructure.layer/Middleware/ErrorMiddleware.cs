using challenge.domain.layer.Models;
using Challenge.infrastructure.layer.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace challenge.infrastructure.layer.Middleware
{
    public class ErrorMiddleware
    {
        private readonly ILogger<ErrorMiddleware> _logger;
        private readonly RequestDelegate _next;
        public ErrorMiddleware(ILogger<ErrorMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException CustomEx)
            {
                await handleError(context, CustomEx);

            }
            catch (Exception ex)
            {
                await handleError(context, ex);
            }

        }

        #region private
        private async Task handleError(HttpContext context,
            Exception ex,
            bool showError = false,
            int? statusCode = null)
        {
            string mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            _logger.LogCritical(exception: ex, message: mensaje);
            context.Response.StatusCode = (statusCode is null) ?
                (int)HttpStatusCode.InternalServerError : (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = new ErrorResult()
            {
                ErrorMostrable = showError,
                MensajeError = mensaje
            }.ToString();
            await context.Response.WriteAsync(response);
        }
        #endregion
    }
}
