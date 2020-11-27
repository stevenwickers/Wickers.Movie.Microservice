using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Wickers.Movie.Business;
using Wickers.Movie.Business.Interfaces;
using Wickers.Movie.Business.Services;
using Wickers.Movie.Models;

namespace Wickers.Movie.API
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
            services.AddControllers();
            services.AddSingleton<IConfiguration>(Configuration);

            var appSettings = (ApplicationSettingsModel)Configuration.GetSection("ApplicationSettings").Get<ApplicationSettingsModel>();
            var swaggerSettings = (SwaggerSettingsModel)Configuration.GetSection("SwaggerSettings").Get<SwaggerSettingsModel>();

            // Get Output source directory of the the applciations
            var sourcePath = Directory.GetParent(typeof(Program).Assembly.Location).FullName;

            //Format the Connection string - must get location of .mdf file
            var connectionString = this.GetConnectionString(sourcePath, appSettings.SqlConnectionString);

            //Services
            services.AddSingleton<ISQLServices>(new SQLServices(connectionString, appSettings.SqlTimeout));
            services.AddSingleton<IServices<MovieModel>, MovieServices>();
            services.AddSingleton<IServices<TVModel>, TVServices>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                 {
                     Version = $"v{swaggerSettings.Version}",
                     Title = swaggerSettings.Title,
                     Description = swaggerSettings.Description,
                     Contact = new OpenApiContact
                     {
                         Name = swaggerSettings.Contact,
                         Email = swaggerSettings.ContactEmail,
                     },
                 });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Use this to get the connection string on individuals computer
        /// </summary>
        /// <param name="ApplciationPath"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        private string GetConnectionString(string ApplciationPath, string ConnectionString)
        {
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(ApplciationPath).Value;
            appRoot = appRoot.Replace("API", "");
            return String.Format(ConnectionString, appRoot);
        }
    }
}
