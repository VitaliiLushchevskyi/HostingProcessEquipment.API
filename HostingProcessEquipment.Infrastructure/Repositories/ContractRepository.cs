using HostingProcessEquipment.Application.Interfaces;
using HostingProcessEquipment.Domain.Entities;
using HostingProcessEquipment.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace HostingProcessEquipment.Infrastructure.Repositories;

internal sealed class ContractRepository(ApplicationDbContext context) : IContractRepository
{
    public async Task<List<EquipmentPlacementContract>> GetContractsAsync(CancellationToken cancellationToken = default)
    {
        return await context.EquipmentPlacementContracts
            .Include(c => c.ProductionFacility) 
            .Include(c => c.ProcessEquipmentType)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(EquipmentPlacementContract contract, CancellationToken cancellationToken = default)
    {
        await context.EquipmentPlacementContracts.AddAsync(contract, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}

