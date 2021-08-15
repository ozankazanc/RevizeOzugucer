using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message) // data vermiyorum, sadece mesaj veriyorum, direk success
        {

        }
        public ErrorDataResult() : base(default, false) //mesaj vermiyorum, datada göndermiyorum, direk success
        {

        }
    }
}
