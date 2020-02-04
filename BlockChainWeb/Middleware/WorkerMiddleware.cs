using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChainWeb.Middleware
{
    public class WorkerMiddleware
    {
        private readonly RequestDelegate _next;
        public WorkerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public void InvokeAsync(HttpContext context)
        {

        }

    }
}
