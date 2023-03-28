using System.Reflection;
using System.Threading.RateLimiting;
using Api.Middleware;
using ApiTrottling.Application;
using ApiTrottling.Application.Common.Behaviours;
using ApiTrottling.Infrastructure;
using ApiTrottling.Infrastructure.Config;
using ApiTrottling.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
var config = new Config(builder.Configuration);

// Add services to the container.
// builder.Services.AddRateLimiter(options =>
// {
//     options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
//         RateLimitPartition.GetSlidingWindowLimiter(
//             partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
//             factory: partition => new SlidingWindowRateLimiterOptions()
//             {
//                 AutoReplenishment = true,
//                 PermitLimit = 100,
//                 QueueLimit = 0,
//                 SegmentsPerWindow = 60,
//                 Window = TimeSpan.FromMinutes(1)
//             }));
//     
//     options.OnRejected = async (context, token) =>
//     {
//         context.HttpContext.Response.StatusCode = 429;
//         
//         await context.HttpContext.Response.WriteAsync(
//                 "Too many requests. Please try again later!");
//     };
// });

ConfigureServices(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseRateLimiter();

ConfigureApplication(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();

void ConfigureServices(IServiceCollection services)
{
    ConfigureRateLimiter(services);
    services.AddSingleton<Microsoft.Extensions.Logging.ILogger>(provider =>
        provider.GetRequiredService<Microsoft.Extensions.Logging.ILogger<Program>>());
    
    services.AddEndpointDefinitions();
    services.AddApplicationServices();
    services.AddInfrastructureServices();
    services.AddTransient<RequestBodyLoggingMiddleware>();
}

void ConfigureApplication(WebApplication app)
{
    app.UseRouting();
    app.UseEndpointDefinitions();
    app.UseCustomExceptionHandler();
    app.UseRequestBodyLogging();
}

void ConfigureRateLimiter(IServiceCollection services)
{
    services.AddRateLimiter(options =>
    {
        options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            RateLimitPartition.GetSlidingWindowLimiter(
                partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
                factory: partition => new SlidingWindowRateLimiterOptions()
                {
                    AutoReplenishment = true,
                    PermitLimit = 100,
                    QueueLimit = 0,
                    SegmentsPerWindow = 60,
                    Window = TimeSpan.FromMinutes(1)
                }));
    
        options.OnRejected = async (context, token) =>
        {
            context.HttpContext.Response.StatusCode = 429;
        
            await context.HttpContext.Response.WriteAsync(
                "Too many requests. Please try again later!");
        };
    });
}

