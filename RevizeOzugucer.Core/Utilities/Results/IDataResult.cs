using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Core.Utilities.Results
{
    public interface IDataResult <T> : IResult
    {
        T Data { get; }
    }
}
