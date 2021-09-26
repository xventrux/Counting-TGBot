using CountingBot.AppServices.Services.CommandService;
using CountingBot.AppServices.Services.ProcessService;
using CountingBot.AppServices.Services.UpdateService;
using CountingBot.AppServices.Services.UserService;
using CountingBot.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountingBot
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
            //Регистрация репозитория
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Регистрация сервисов
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IUpdateService, UpdateService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProcessService, ProcessService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
