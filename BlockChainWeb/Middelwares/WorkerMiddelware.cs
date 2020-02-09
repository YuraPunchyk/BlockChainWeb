using BlockChainWeb.Models.HellperClasses;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

namespace BlockChainWeb.Middelwares {
	public class WorkerMiddelware {
		private readonly RequestDelegate _next;

		private const string teacher = "Teacher";
		private const string student = "Student";
		private const string admin = "Admin";
		public WorkerMiddelware ( RequestDelegate next ) {
			_next = next;
		}
		public async Task InvokeAsync ( HttpContext context ) {
			var status = context.Request.Cookies[Consts.ConstCookieStatus];
			var url = context.Request.Path.ToString();
			if(!string.IsNullOrEmpty(status) && status != "0") {
				if(status == "1") {
					if(url.Contains(admin)) {
						await _next.Invoke(context);
					} else {
						context.Request.Path = "/Access/Index";
						await _next.Invoke(context);
					}
				} else {
					if(status == "2") {
						if(url.Contains(teacher)) {
							await _next.Invoke(context);
						} else {
							context.Request.Path = "/Access/Index";
							await _next.Invoke(context);
						}
					} else {
						if(status == "3") {
							if(url.Contains(student)) {
								await _next.Invoke(context);
							} else {
								context.Request.Path = "/Access/Index";
								await _next.Invoke(context);
							}
						}
					}
				}
				context.Request.Path = "/Account/Authentication";
				await _next.Invoke(context);
			} else {
				context.Request.Path = "/Account/Authentication";
				await _next.Invoke(context);
			}

		}
	}
}
