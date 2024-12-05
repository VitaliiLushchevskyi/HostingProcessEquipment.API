using HostingProcessEquipment.Domain.Entities;

namespace HostingProcessEquipment.Application.Interfaces;

public interface IProductionFacilityRepository
{
    Task<ProductionFacility?> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
}

