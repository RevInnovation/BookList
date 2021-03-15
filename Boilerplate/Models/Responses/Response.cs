using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Models.Responses
{
    public class Response<T>
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }

        public static Response<T> Get(IHttpContextAccessor contextAccessor, T data)
        {
            contextAccessor.HttpContext.Response.StatusCode = 200;
            return new Response<T>
            {
                IsError = false,
                Message = "Get Request Successful",
                StatusCode = 200,
                Data = data,
            };
        }
        public static Response<T> Post(IHttpContextAccessor contextAccessor, T data)
        {
            contextAccessor.HttpContext.Response.StatusCode = 201;
            return new Response<T>
            {
                IsError = false,
                Message = "Post Request Successful",
                StatusCode = 201,
                Data = data,
            };
        }
        public static Response<T> Put(IHttpContextAccessor contextAccessor, T data)
        {
            contextAccessor.HttpContext.Response.StatusCode = 200;
            return new Response<T>
            {
                IsError = false,
                Message = "Put Request Successful",
                StatusCode = 201,
                Data = data,
            };
        }
        public static Response<T> Patch(IHttpContextAccessor contextAccessor, T data)
        {
            contextAccessor.HttpContext.Response.StatusCode = 200;
            return new Response<T>
            {
                IsError = false,
                Message = "Patch Request Successful",
                StatusCode = 201,
                Data = data,
            };
        }
        public static Response<T> Delete(IHttpContextAccessor contextAccessor, T data)
        {
            contextAccessor.HttpContext.Response.StatusCode = 200;
            return new Response<T>
            {
                IsError = false,
                Message = "Delete Request Successful",
                StatusCode = 201,
                Data = data,
            };
        }
    }
}
