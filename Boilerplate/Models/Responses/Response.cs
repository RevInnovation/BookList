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

        public static Response<T> Get(T data)
        {
            return new Response<T>
            {
                IsError = false,
                Message = "Get Request Successful",
                StatusCode = 200,
                Data = data,
            };
        }
        public static Response<T> Post(T data)
        {
            return new Response<T>
            {
                IsError = false,
                Message = "Post Request Successful",
                StatusCode = 201,
                Data = data,
            };
        }
        public static Response<T> Put(T data)
        {
            return new Response<T>
            {
                IsError = false,
                Message = "Put Request Successful",
                StatusCode = 201,
                Data = data,
            };
        }
        public static Response<T> Patch(T data)
        {
            return new Response<T>
            {
                IsError = false,
                Message = "Patch Request Successful",
                StatusCode = 201,
                Data = data,
            };
        }
        public static Response<T> Delete(T data)
        {
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
