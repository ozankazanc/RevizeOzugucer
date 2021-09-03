﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RevizeOzugucer.Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
