using HostingProcessEquipment.Application.Interfaces;
using HostingProcessEquipment.Domain.Entities;
using HostingProcessEquipment.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace HostingProcessEquipment.Infrastructure.Repositories;

internal sealed class EquipmentTypeRepository(ApplicationDbContext context) : IEquipmentTypeRepository
{
    public async Task<ProcessEquipmentType?> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        return await context.ProcessEquipmentTypes
            .FirstOrDefaultAsync(e => e.Code == code, cancellationToken);
    }
}

