using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.CHEM.MBR.DATAACCESS.AppModels.Common
{
    public class CommonResultModel<T>
    {
        public long? Id { get; set; }
        public bool? IsSuccess { get; set; }
        public string? Message { get; set; }
        public string Error { get; set; }
        public List<string> Errors { get; set; }
        public int? Status { get; set; }
        public T Data { get; set; }
        public int? Total { get; set; }

        public static CommonResultModel<T> Success()
        {
            return new CommonResultModel<T>() { IsSuccess = true, Status = 200 };
        }
        public static CommonResultModel<T> Success<T>(T data)
        {
            return new CommonResultModel<T>() { Data = data, IsSuccess = true, Status = 200 };
        }
        public static CommonResultModel<T> Success<T>(T data, int? total)
        {
            return new CommonResultModel<T>() { Data = data, IsSuccess = true, Status = 200, Total = total };
        }
        public static CommonResultModel<T> Success<T>(T data, int? total, string? msg)
        {
            return new CommonResultModel<T>() { Data = data, IsSuccess = true, Status = 200, Total = total, Message = msg };
        }
        public static CommonResultModel<T> Fail()
        {
            return new CommonResultModel<T>() { IsSuccess = false, Status = 400 };
        }
        public static CommonResultModel<List<string>> Fail(List<string> errors)
        {
            return new CommonResultModel<List<string>>() { Errors = errors, IsSuccess = false, Status = 400 };
        }
        public static CommonResultModel<T> Fail(string msg, string? stackTrace)
        {
            return new CommonResultModel<T>() { IsSuccess = false, Status = 500, Error = msg, Errors = new List<string>() { stackTrace } };
        }
    }
}