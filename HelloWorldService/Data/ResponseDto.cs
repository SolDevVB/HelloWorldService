﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldService.Data
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string WarningMessage { get; set; }
        public string Message { get; set; }
        public T Dto { get; set; }
    }
}
