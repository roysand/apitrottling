using MediatR;

namespace ApiTrottling.Application.Common.CommandsAndQueries.GetDate.Queries.GetDate;
public class GetDateQuery : IRequest<GetDateVm>
{
}

public class GetDateHandler : IRequestHandler<GetDateQuery, GetDateVm>
{
    public GetDateHandler()
    {
        
    }
    public async Task<GetDateVm> Handle(GetDateQuery request, CancellationToken cancellationToken)
    {
        var result = Task.Run(() => new GetDateVm()).Result;
        return result;
    }
}
