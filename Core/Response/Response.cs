using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Core.Response
{
    public class Response<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }

        public static Response<T> Success(T data,int statusCode = 200)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccess = true };
        }
        public static Response<T> Success(int statusCode = 200)
        {
            return new Response<T> { Data = default, StatusCode = statusCode, IsSuccess = true };
        }
        public static Response<T> Success()
        {
            return new Response<T> { Data = default, StatusCode = 200, IsSuccess = true };
        }
        public static Response<T> Fail(List<string> errors, int statusCode=404)
        {
            return new Response<T> { Errors = errors, StatusCode = statusCode, IsSuccess = false };
        }
        public static Response<T> Fail(string error, int statusCode = 404)
        {
            return new Response<T> { Errors = new List<string> { error }, StatusCode = statusCode, IsSuccess = false };
        }


    }
}
