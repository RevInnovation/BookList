using AutoWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Models.Responses
{
    public class ErrorResponse
    {
        public static ApiException BadRequest()
        {
            return new ApiException("Bad Request", 400);
        }
        public static ApiException UnAuthorized()
        {
            return new ApiException("Unauthorized", 401);
        }
        public static ApiException Forbidden()
        {
            return new ApiException("Forbidden", 403);
        }
        public static ApiException NotFound(string entity)
        {
            return new ApiException($"{entity} Not Found", 404);
        }
        public static ApiException InternalServerError(Exception ex)
        {
            return new ApiException(ex, 500);
        }
        public static ApiException ServiceUnavailable()
        {
            return new ApiException("Service Unavailable", 503);
        }
    }
}
