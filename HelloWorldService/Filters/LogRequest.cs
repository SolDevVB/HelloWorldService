using HelloWorldService.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace HelloWorldService.Filters
{
    public class LogRequest : ActionFilterAttribute , IAsyncActionFilter
    {

        private readonly LogContext _context;

        public LogRequest(LogContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var req = GetRequestLogDto(context);
            _context.RequestLogs.Add(req);
            _context.SaveChanges();

            base.OnActionExecuting(context);
        }


        private RequestLog GetRequestLogDto(ActionExecutingContext context)
        {
            return new RequestLog() {Id = Guid.NewGuid(), RequestUrl = context.HttpContext.Request.Path.Value, CallingIP = context.HttpContext.Connection.LocalIpAddress.ToString(), RequestDate = DateTime.Now };
        }
    }
}
