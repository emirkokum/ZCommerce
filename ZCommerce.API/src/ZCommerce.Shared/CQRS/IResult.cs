using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCommerce.Shared.CQRS
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }

    public class SuccessResult : IResult
    {
        public SuccessResult(string message = "")
        {
            IsSuccess = true;
            Message = message;
        }

        public bool IsSuccess { get; }
        public string Message { get; }
    }

    // Hata durumunu belirten sonuç
    public class ErrorResult : IResult
    {
        public ErrorResult(string message)
        {
            IsSuccess = false;
            Message = message;
        }

        public bool IsSuccess { get; }
        public string Message { get; }
    }

}
