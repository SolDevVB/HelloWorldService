using Microsoft.EntityFrameworkCore;

namespace HelloWorldService.Data
{
    public class LogContext :DbContext
    {

        public LogContext(DbContextOptions<LogContext> options) : base(options) { }

        public DbSet<RequestLog> RequestLogs { get; set; }
    }
}
