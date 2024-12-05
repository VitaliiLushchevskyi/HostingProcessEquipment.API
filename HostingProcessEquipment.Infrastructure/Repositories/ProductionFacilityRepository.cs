using HostingProcessEquipment.Application.Interfaces;
using HostingProcessEquipment.Domain.Entities;
using HostingProcessEquipment.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace HostingProcessEquipment.Infrastructure.Repositories;

internal sealed class ProductionFacilityRepository(ApplicationDbContext context) : IProductionFacilityRepository
{
    public async Task<ProductionFacility?> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        return await context.ProductionFacilities
            .FirstOrDefaultAsync(f => f.Code == code, cancellationToken);
    }
}

