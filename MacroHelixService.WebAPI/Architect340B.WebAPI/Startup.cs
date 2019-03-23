using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Architect340B.AutoMapperConfig;
using Business.Architect340B.Services.Contracts;
using Business.Architect340B.Services.Implements;
using EFCore.ArchitectMain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using AutoMapper;

namespace Architect340B.WebAPI
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
            #region MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                            .AddJsonOptions(options =>
                            {
                                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                            });
            #endregion

            #region Inject EF DbContext
            services.AddDbContext<ArchitectMainDbContext>(options => options.UseSqlServer(Configuration["AppSettings:ConnectionString"]));
            #endregion

            #region Register AutoMapper Service
            services.AddAutoMapper(typeof(Architect340BAutoMapperConfig));
            #endregion

            #region Inject Business Service Layer
            services.AddScoped<IDrugPropertiesService, DrugPropertiesService>();
            #endregion

            #region SETUP CORS
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            #region Install CORS
            app.UseCors("EnableCORS");
            #endregion
        }
    }
}
