using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EventApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostContext, services) =>
                    {
                        // Add services to the container.
                        services.AddControllers();
                        services.AddSwaggerGen();
                    })
                    .Configure((hostContext, app) =>
                    {
                        // Configure the HTTP request pipeline.
                        if (hostContext.HostingEnvironment.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                            app.UseSwagger();
                            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Event API v1"));
                        }

                        app.UseHttpsRedirection();

                        app.UseRouting();

                        app.UseAuthentication();
                        app.UseAuthorization();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });

            builder.Build().Run();
        }
    }
}
