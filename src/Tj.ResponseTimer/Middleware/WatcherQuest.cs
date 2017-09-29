using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tj.ResponseTimer.Models;

namespace Tj.ResponseTimer.Middleware
{
    public class WatcherQuest
    {
        private readonly RequestDelegate _next;
        public AppDbContext appDbContext;

        public WatcherQuest(RequestDelegate next, AppDbContext _appDbContext)
        {
            this._next = next;
            appDbContext = _appDbContext;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
 
            context.Response.OnCompleted(state =>
            {
            sw.Stop();
            var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
                if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
                {
                    string path = string.Concat(
                                           context.Request.Scheme,
                                           "://",
                                           context.Request.Host.Value,
                                           context.Request.PathBase.Value,
                                           context.Request.Path.Value);

                    DateTime dt = Convert.ToDateTime(context.Response.Headers["Date"]);            
                    RequestResponseTime rrt = appDbContext.Rrt.FirstOrDefault(x => x.PagePath == path);

                    Int64 datend = dt.Ticks;
                    Int64 wsElapsed = sw.ElapsedTicks;

                    if (null != rrt)
                    {
                        rrt.MeasureTime = wsElapsed;
                        rrt.ServerIn = datend - wsElapsed;
                        rrt.ServerOut = datend;
                    }
                    else
                    {
                        appDbContext.Rrt.Add(new RequestResponseTime
                        {
                            PagePath = path,
                            MeasureTime = wsElapsed,
                            ServerIn = datend - wsElapsed,
                            ServerOut = datend,
                        });
                    }
                   appDbContext.SaveChangesAsync();
                }
                return Task.FromResult(0);
            }, context);

           await _next(context);
        }
    }
}
