using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using Auth.ApiDataAccess;
using Auth.Business;
using Auth.DataAccess.Contexts;
using Auth.DataAccess.InterfaceContexts;
using Auth.DataAccess;
using Auth.Extention;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // DATABASE CONNECTION STRINGS
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var strAuth = new SqliteConnectionStringBuilder
            {
                DataSource = ".\\AuthDbLite.db",
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = "MyPassword"
            }.ToString();
            var strCalc = new SqliteConnectionStringBuilder
            {
                DataSource = ".\\CalcDbLite.db",
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = "MyPassword"
            }.ToString();

            var strTax = new SqliteConnectionStringBuilder
            {
                DataSource = ".\\TaxDbLite.db",
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = "MyPassword"
            }.ToString();
            var strApi = new SqliteConnectionStringBuilder
            {
                DataSource = ".\\ApiDbLite.db",
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = "MyPassword"
            }.ToString();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Authentication DB
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            services.AddDbContext<DataContext>
                (
                options => options.UseSqlite(strAuth,
                    mig => mig.MigrationsAssembly( typeof(DataContext).Assembly.FullName))
                );
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Calculations DB DB
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////

            services.AddDbContext<DataContextCalc>
                (
                options => options.UseSqlite(strCalc,
                    mig => mig.MigrationsAssembly(typeof(DataContextCalc).Assembly.FullName))
                );
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Tax DB
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            services.AddDbContext<DataContextTax>
                (
                options => options.UseSqlite(strTax, 
                    mig => mig.MigrationsAssembly(typeof(DataContextTax).Assembly.FullName))
                );
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // API DB
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            services.AddDbContext<DataContextApi>
            (
                options => options.UseSqlite(strApi, 
                    mig => mig.MigrationsAssembly(typeof(DataContextApi).Assembly.FullName))
            );

            #region Swagger

            services.AddSwaggerGen(s=>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Tax API",
                    Description = "<h1>Order Tax API<h1>",
                    TermsOfService = new Uri("https://linkedin.com/patrickgourdet"),
                    Contact = new OpenApiContact
                    {
                        Name = "Patrick Gourdet",
                        Email = "patrickgourdet@protonmail.com",
                        Url = new Uri("https://linkedin.com/patrickgourdet"),
                    },
                });
                var xmlPath = "./Auth.xml";
                s.IncludeXmlComments(xmlPath);
            });

            #endregion

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes
                            (
                                Configuration.GetSection("AppSettings:Token").Value)
                            ),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddScoped<ICalculate, Calculate>();
            services.AddScoped<ICalculatorApiAccessor, CalculatorTaxTatesAPIAccessor>();
            services.AddScoped<ITaxRates, TaxRatesByZIPCodeAPIAccessor>();
            services.AddScoped<ITaxServiceDbContext, TaxServiceDbContext>();
            services.AddScoped<ICalculateDbContext,CalculatorDbContext>();
            services.AddScoped<IAuthContext,AuthContext>();
            services.AddScoped<IApiDbContext,ApiDbContext>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                //Global Exception Handler 
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //Here we apply our excetpion Handler headers so that we can pass them to the front end
                        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            //app.UseHsts();

            app.UseHttpsRedirection();

            app.UseRouting();
            SwaggerUIOptions h = new SwaggerUIOptions();
            app.UseAuthorization();
            app.UseStaticFiles();
            #region Swagger


            #endregion

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}