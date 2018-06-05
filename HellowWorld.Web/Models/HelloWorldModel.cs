using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HellowWorld.Web.Models
{
    public class HelloWorldModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string WarningMessage { get; set; }
        public string Message { get; set; }
        public string Dto { get; set; }
    }
}
