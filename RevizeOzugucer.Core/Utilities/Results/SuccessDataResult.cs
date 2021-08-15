using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data,true,message)
        {
           
        }
        public SuccessDataResult(T data) : base(data,true)
        {
            
        }
        public SuccessDataResult(string message):base(default,true,message) // data vermiyorum, sadece mesaj veriyorum, direk success
        {

        }
        public SuccessDataResult(): base(default,true) //mesaj vermiyorum, datada göndermiyorum, direk success
        {

        }
    }
}
