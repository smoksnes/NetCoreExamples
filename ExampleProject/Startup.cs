using System;
using System.IO;
using ExampleProject.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;

namespace ExampleProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			// Krävs för att UseMvc() Ska fungera.
	        services.AddMvc(); // Decompila och visa vad den innehåller

			// AutoMapper.Extensions.Microsoft.DependencyInjection
	        services.AddAutoMapper();

	        services.AddSwaggerGen(c =>
	        {
		        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
	        });

			services.AddTransient<ISuperCalculator, SuperCalculator>();

			services.AddDbContext<MyContext>(builder =>
		        builder.UseSqlServer(Configuration.GetConnectionString("Model"))
	        );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

	        var builder = new ConfigurationBuilder()
		        .SetBasePath(Directory.GetCurrentDirectory())
		        .AddJsonFile($"appsettings.{Environment.UserName}.json", optional: true)
		        .AddEnvironmentVariables()
		        .AddUserSecrets<Startup>()
				.AddJsonFile("appsettings.json");

	        Configuration = builder.Build();

			// Link in code compiles. But why?
			https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.0&tabs=aspnetcore2x

			//app.Run(async (context) =>
			//         {
			//             await context.Response.WriteAsync("Hello World!");
			//         });

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			app.UseStaticFiles();
			app.UseSwagger();

			//app.UseMvc();
		}

	    public IConfiguration Configuration { get; set; }
    }
}
