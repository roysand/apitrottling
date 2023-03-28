using ApiTrottling.Domain.Entities;
using ApiTrottling.Domain.Entities.EF;
using Microsoft.EntityFrameworkCore;

namespace ApiTrottling.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<PrefDbLoginPerson> PrefDbLoginPersonSet { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
