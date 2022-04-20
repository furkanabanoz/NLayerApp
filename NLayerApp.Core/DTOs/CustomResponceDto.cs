using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayerApp.Core.DTOs
{
    public class CustomResponceDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int statusCode { get; set; }
        public List<String> Errors { get; set; }

        public static CustomResponceDto<T> Success(int statusCode,T data) 
        {
            return new CustomResponceDto<T> { statusCode=statusCode, Data=data };
        }
        public static CustomResponceDto<T> Success(int statusCode)
        {
            return new CustomResponceDto<T> { statusCode = statusCode};
        }
        public static CustomResponceDto<T> Fail(int statusCode,List<string> errors)
        {
            return new CustomResponceDto<T> { statusCode = statusCode,Errors=errors };
        }
        public static CustomResponceDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponceDto<T> { statusCode = statusCode, Errors = new List<string> { error } };
        }

    }
}
