using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CertificateService.Data;

namespace CertificateService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(opt => 
            opt.UseInMemoryDatabase("InMemory"));
            
            services.AddScoped<ICertificateRepo, CertificateRepo>();
            services.AddControllers(); // Register MVC controllers

            // Add Swagger services
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Certificate API",
                    Version = "v1",
                    Description = "API documentation for CertificateService",
                });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable Swagger middleware in the development environment
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatformService API v1");
                    c.RoutePrefix = string.Empty; // Set Swagger UI at the root of the application
                });
            }

            app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS

            app.UseRouting();

            app.UseAuthorization();
            
            PrepDB.PrepPopulation(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map controller routes
            });

        }
    }
}
