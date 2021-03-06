using CoinMarketApp.Auth;
using DataStore.EF.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.ApplicationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinMarketApp
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env,IConfiguration configuration )
        {
            _env = env;
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomTokenManager, JwtTokenManager>();
            services.AddSingleton<ICustomUserManager, CustomUserManager>();
            

            if (_env.IsDevelopment())
            {
                services.AddDbContext<CoinMarketDbContext>(options=>
                {
                    options.UseInMemoryDatabase("CoinDb");
                });
            }
            else if(_env.IsStaging() || _env.IsProduction()){
                services.AddDbContext<CoinMarketDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            }
            services.AddControllers();

            services.AddApiVersioning(options => {
                options.ReportApiVersions = true; // response header shows the supported api versionS* if a user tries to reach an unsupported version
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");
            });
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Web API v1", Version = "version 1" });

            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://localhost:44398") 
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,CoinMarketDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                //Configure OpenAPI
                app.UseSwagger();
                app.UseSwaggerUI(
                    options => {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
                    });
            }
           
            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
