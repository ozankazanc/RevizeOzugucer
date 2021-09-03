using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Core.Utilities.Results
{
    
    public class Result : IResult
    {
        //Get yani readonly olan property'ler ancak constructor'da set edilebilir.
        public Result(bool success)
        {
            IsSuccess = success;
        }
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

        public bool IsSuccess { get; }

        public string Message { get; }

        //public string Message => throw new NotImplementedException(); lambda kullanımı yeni, aslında get'tir. Lambdadan sonra ne varsa onu geri döner.
    }
}
