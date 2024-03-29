﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calories.Api.Setups;
using Calories.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MissingDIExtensions;
using Ninject;

namespace Calories.Api
{
    public class Startup
    {
        private CaloriesNinject CNinject = new CaloriesNinject();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddRequestScopingMiddleware(() => CNinject.ScopeProvider.Value = new Others.Scope());
            services.AddCustomControllerActivation(CNinject.Resolve);
            services.AddCustomViewComponentActivation(CNinject.Resolve);
            services.AddControllers();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            CNinject.RegisterApplicationComponents(app, loggerFactory);
            CaloriesContext dbContext = CNinject.Kernel.TryGet<CaloriesContext>();
            dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:9080", "http://10.144.78.142", "http://localhost:10000", "http://192.168.43.52:9080", "http://10.144.224.103:9080", "http://calories.laczak.net.pl:9080")
            .AllowAnyMethod()
            .AllowAnyHeader()
            );

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

      
    }
}
