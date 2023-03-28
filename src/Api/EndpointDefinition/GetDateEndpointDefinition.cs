using System.Net;
using ApiTrottling.Application.Common.CommandsAndQueries.GetDate.Queries.GetDate;
using ApiTrottling.Application.Common.Interfaces;
using MediatR;

namespace Api.EndpointDefinition;

public class GetDateEndpointDefinition : IEndpointDefinition
{
    public void DefineServices(IServiceCollection services)
    {
        // throw new NotImplementedException();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/api/getdate", GetDate)
            .Produces((int)HttpStatusCode.OK)
            .WithName("GetDate")
            .WithTags("Date")
            .WithOpenApi();
    }

    private async Task<IResult> GetDate(IMediator mediator)
    {
        var result = await mediator.Send(new GetDateQuery());
        return Results.Ok(result);
    }
}
