using System.IO;
using BlockChainWeb.Middelwares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace BlockChainWeb {
	public class Startup {
		public Startup ( IConfiguration configuration ) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices ( IServiceCollection services ) {
			AppConfiguration appConfig = new AppConfiguration();
			var configBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true);
			configBuilder.Build().Bind(appConfig);
			services.AddSingleton<AppConfiguration>(appConfig);
			services.AddHttpContextAccessor();
			services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
			services.AddControllersWithViews();
		}

		public void Configure ( IApplicationBuilder app, IWebHostEnvironment env ) {
			if(env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseMiddleware<WorkerMiddelware>();
			app.UseRouting();
		
			app.UseAuthorization();
			app.UseEndpoints(endpoints => {
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Account}/{action=Authentication}/{id?}");
			});
		}
	}
}