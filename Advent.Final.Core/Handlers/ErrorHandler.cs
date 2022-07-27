using System;
using System.Net;
using Advent.Final.Entities.Utils;
using Microsoft.Extensions.Logging;

namespace Advent.Final.Core.Handlers
{
    public class ErrorHandler<T>
    {
        private readonly ILogger<T> _logger;

        public ErrorHandler(ILogger<T> logger)
        {
            _logger = logger;
        }

        public ResponseService<U> Error<U>(Exception ex, string serviceName, U content)
        {
            string innerException = ex.InnerException == null ? string.Empty : ex.InnerException.Message;
            _logger.LogError(ex, $"Service: {serviceName}, Message: {ex.Message}, InnerMessage: {innerException}");
            return new ResponseService<U>(true, $"Exception: {ex.Message}, InnerMessage: {innerException}", HttpStatusCode.InternalServerError, content);
        }
    }
}
