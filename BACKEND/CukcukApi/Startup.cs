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
using Microsoft.OpenApi.Models;

using CukcukCore.Interfaces.BusinessServices;
using CukcukCore.BusinessServices;
using CukcukCore.Interfaces.Repositories;
using MariaInfrastructure.Repositories;

namespace CukcukApi
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
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "CukcukApi", Version = "v1" });
			});

			// TIÊM: XỬ LÝ DI: Dependencies injection cho interface
			services.AddScoped<ICustomerService, CustomerService>();
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<IEmployeeService, EmployeeService>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			// TIÊM: XỬ LÝ DI: Dependencies injection cho generic interface
			services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
			services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CukcukApi v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
