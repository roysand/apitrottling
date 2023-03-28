using AutoMapper;
using ApiTrottling.Application.Common.Exceptions;
using ApiTrottling.Application.Common.Interfaces;
using ApiTrottling.Application.Common.Interfaces.Repositories;
using ApiTrottling.Domain.Entities.EF;
using ApiTrottling.Domain.ValueObjects;
using MediatR;

namespace ApiTrottling.Application.Common.CommandsAndQueries.Person.Queries.GetPersonByMobilePhone;

public class GetPersonByMobilePhoneQuery : IRequest<GetPersonByMobilePhoneVm>
{
    public string MobilePhone { get; set; }

    public GetPersonByMobilePhoneQuery(string mobilePhone)
    {
        MobilePhone = mobilePhone;
    }
}

public class GetPersonByMobilePhoneHandler : IRequestHandler<GetPersonByMobilePhoneQuery, GetPersonByMobilePhoneVm>
{
    private readonly IPrefDbLoginPersonRepository<PrefDbLoginPerson> _prefDbLoginPersonRepository;
    private readonly IMapper _mapper;
    private readonly IConfig _config;

    public GetPersonByMobilePhoneHandler(IPrefDbLoginPersonRepository<Domain.Entities.EF.PrefDbLoginPerson> prefDbLoginPersonRepository
        , IMapper mapper, IConfig config)
    {
        _prefDbLoginPersonRepository = prefDbLoginPersonRepository;
        _mapper = mapper;
        _config = config;
    }
    public async Task<GetPersonByMobilePhoneVm> Handle(GetPersonByMobilePhoneQuery request, CancellationToken cancellationToken)
    {
        var mobilePhone = MobilePhone.For(request.MobilePhone, _config.SmsConfig.SmsMobilePhoneCountryCode());
        var entity = await _prefDbLoginPersonRepository.Get(mobilePhone, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(ExceptionEnums.SearchEntityNotFound, $"Person with mobile number = '{mobilePhone}' is not found!");
        }
    
        var result = _mapper.Map<GetPersonByMobilePhoneVm>(entity);
        return result;
    }
}
