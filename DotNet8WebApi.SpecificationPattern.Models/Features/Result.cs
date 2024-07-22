using DotNet8WebApi.SpecificationPattern.Models.Enums;
using DotNet8WebApi.SpecificationPattern.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.SpecificationPattern.Models.Features
{
    public class Result<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public EnumStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError => !IsSuccess;

        public static Result<T> SuccessResult(string message = "Success.", EnumStatusCode statusCode = EnumStatusCode.Success)
        {
            return new Result<T> { Message = message, StatusCode = statusCode, IsSuccess = true };
        }

        public static Result<T> SuccessResult(T data, string message = "Success.", EnumStatusCode statusCode = EnumStatusCode.Success)
        {
            return new Result<T> { Data = data, Message = message, StatusCode = statusCode, IsSuccess = true };
        }

        public static Result<T> FailureResult(string message = "Fail.", EnumStatusCode statusCode = EnumStatusCode.BadRequest)
        {
            return new Result<T> { Message = message, StatusCode = statusCode, IsSuccess = false };
        }

        public static Result<T> FailureResult(Exception ex)
        {
            return new Result<T> { Message = ex.ToString(), StatusCode = EnumStatusCode.InternalServerError, IsSuccess = false };
        }

        public static Result<T> NotFoundResult(string message = "No Data Found.")
        {
            return new Result<T> { Message = message, StatusCode = EnumStatusCode.NotFound, IsSuccess = false };
        }

        public static Result<T> DuplicateResult(string message = "Duplicate Data.")
        {
            return new Result<T> { Message = message, StatusCode = EnumStatusCode.Conflict, IsSuccess = false };
        }

        public static Result<T> ExecuteResult(int result)
        {
            return result > 0 ? Result<T>.SuccessResult() : Result<T>.FailureResult();
        }
    }
}