using HostingProcessEquipment.Domain.Entities;

namespace HostingProcessEquipment.Application.Interfaces;

public interface IContractRepository
{
    Task<List<EquipmentPlacementContract>> GetContractsAsync(CancellationToken cancellationToken = default);
    Task AddAsync(EquipmentPlacementContract contract, CancellationToken cancellationToken = default);
}

