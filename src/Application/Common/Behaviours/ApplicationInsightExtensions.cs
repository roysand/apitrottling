using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace ApiTrottling.Application.Common.Behaviours;
public static class ApplicationInsightExtensions
{
    public static IApplicationBuilder UseRequestBodyLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestBodyLoggingMiddleware>();
    }
}

