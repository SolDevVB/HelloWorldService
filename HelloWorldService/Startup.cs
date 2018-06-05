using HelloWorldService.Data;
using HelloWorldService.Filters;
using HelloWorldService.Logic;
using HelloWorldService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HelloWorldService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LogContext>(options => options.UseInMemoryDatabase(Configuration.GetConnectionString("LogLocal")));
            services.AddScoped<LogRequest>();

            services.AddSingleton<IHelloWorldRepo, HelloWorldRepo>();
            services.AddSingleton<IHelloWorldLogic, HelloWorldLogic>();

            services.Configure<ConfigOptions>(Configuration.GetSection("Options"));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

    }
}
