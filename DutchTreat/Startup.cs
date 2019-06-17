using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Contracts;
using DutchTreat.Data;
using DutchTreat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DutchTreat.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DutchTreat.Data.Entities;
using DutchTreat.Models;

namespace DutchTreat
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DutchContext>(cfg => {
                cfg.UseSqlServer(_config.GetConnectionString("DefaultConnectionString"));
            });

            services.AddTransient<DutchSeeder>();
            services.AddTransient<IMailService, EmailService>();
            services.AddScoped<IDutchRepository, DutchRepository>();
            
            services.AddMvc()
                .AddJsonOptions(opt => 
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();

            app.UseMvc(cfg => {
                cfg.MapRoute("Default", 
                "/{controller}/{action}/{id?}",
                new { controller = "App", Action = "Index"});
            });

            AutoMapper.Mapper.Initialize(
                cfg => {
                    cfg.CreateMap<Order, OrderDto>().ReverseMap();
                    cfg.CreateMap<Product, ProductDto>().ReverseMap();
                    cfg.CreateMap<OrderItem, OrderItemDto>().ReverseMap();
                }
            );
        }
    }
}
