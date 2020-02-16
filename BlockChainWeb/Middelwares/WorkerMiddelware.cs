using BlockChainWeb.DbContexts;
using BlockChainWeb.Models.Education;
using BlockChainWeb.Models.HellperClasses;
using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

namespace BlockChainWeb.Middelwares {
	public class WorkerMiddelware {
		private readonly RequestDelegate _next;

		#region Private Veriables
		private const string teacher = "Teacher";
		private const string student = "Student";
		private const string admin = "Admin";
		#endregion

		private DbContext _dbContexts;
		public WorkerMiddelware ( RequestDelegate next, AppConfiguration appConfiguration ) {
			_next = next;
			_dbContexts = new DbContext(appConfiguration.Dbsetting.Connection);
		}

		public async Task InvokeAsync ( HttpContext context ) {
			var status = context.Request.Cookies[Consts.ConstCookieStatus];
			var url = context.Request.Path.ToString();
			if(url == "/") {
				context.Request.Path = "/Account/Authentication";
			} else {
				if(status != "1") {
					if(url != "/Account/Logout") {
						if(!string.IsNullOrEmpty(status) && status != "0") {
							if(status == "1") {
								if(!url.Contains(admin)) {
									context.Request.Path = "/Access/Index";
								}
							} else {
								if(status == "2") {
									if(!url.Contains(student)) {
										context.Request.Path = "/Access/Index";
									}
								} else {
									if(status == "3") {
										if(!url.Contains(teacher)) {
											context.Request.Path = "/Access/Index";
										}
									}
								}
							}
						} else {
							if(url != "/Account/Login") {
								context.Request.Path = "/Account/Authentication";
							}

						}
					}
				}
			}
			await _next.Invoke(context);
		}
	}
}