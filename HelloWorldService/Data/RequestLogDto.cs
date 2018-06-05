using System;

namespace HelloWorldService.Data
{
    public class RequestLog
    {
        public Guid Id { get; set; }
        public string RequestUrl { get; set; }
        public string CallingIP { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
