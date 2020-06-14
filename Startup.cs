using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ManageUsersApi.Data;
using ManageUsersApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using ManageUsersApi.Util;

namespace ManageUsersApi
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
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? Configuration.GetConnectionString("Connection");
            services.AddDbContext<ManageUsersContext>(options =>
                options.UseNpgsql(
                    connectionString
                )
            );
             services.AddControllers().AddNewtonsoftJson(s => {
                        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserRepo, PGUserRepo>();            
            
            // services.AddSwaggerGen(c=> {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manage Users API", Version = "v1" });
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

        
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            PrepDB.prepDataBase(app);
        }
    }
}
