using ApiTrottling.Application.Common.Interfaces.Repositories;
using ApiTrottling.Domain.Entities;
using ApiTrottling.Domain.Entities.EF;
using ApiTrottling.Infrastructure.Persistence;

namespace ApiTrottling.Infrastructure.Repositories.EF;

public class PrefDbLoginPersonRepository : GenericEFRepository<PrefDbLoginPerson>, IPrefDbLoginPersonRepository<PrefDbLoginPerson>
{
    public PrefDbLoginPersonRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }
}