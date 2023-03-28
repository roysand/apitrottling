using System.Net;
using ApiTrottling.Application.Common.CommandsAndQueries.Person.Queries.GetPersonByMobilePhone;
using ApiTrottling.Application.Common.Exceptions;
using ApiTrottling.Application.Common.Interfaces;
using ApiTrottling.Application.Common.Interfaces.Repositories;
using ApiTrottling.Application.Common.Models;
using ApiTrottling.Domain.Entities;
using ApiTrottling.Domain.Entities.EF;
using ApiTrottling.Domain.Exceptions;
using ApiTrottling.Infrastructure.Repositories.EF;
using MediatR;

namespace Api.EndpointDefinition;

public class PersonEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/api/person/{mobilePhone}", GetPersonByMobileNumber)
            .Produces((int)HttpStatusCode.BadRequest)
            .Produces((int)HttpStatusCode.OK) // , typeof(GetPersonByMobilePhoneVm))
            // .Produces((int)HttpStatusCode.NotFound, typeof(NotFoundExceptionVm))
            .Produces((int)HttpStatusCode.TooManyRequests)
            .WithName("GetPersonByMobilePhone")
            .WithTags("Person");
    }
    
    private async Task<IResult> GetPersonByMobileNumber(string mobilePhone, IMediator mediator)
    {
        var query = new GetPersonByMobilePhoneQuery(mobilePhone);
        var result = await mediator.Send(query);

        return Results.Ok(result);
    }
    
    public void DefineServices(IServiceCollection services)
    {
        services.AddTransient<IPrefDbLoginPersonRepository<PrefDbLoginPerson>, PrefDbLoginPersonRepository>();
    }
}
