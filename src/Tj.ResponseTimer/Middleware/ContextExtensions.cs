using Microsoft.AspNet.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tj.ResponseTimer.Middleware
{
    public static class ContextExtensions
    {
        public static IApplicationBuilder BeginEndRequest(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WatcherQuest>();
        }
    }
}
