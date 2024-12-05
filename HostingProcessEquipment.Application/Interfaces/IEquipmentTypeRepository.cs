using HostingProcessEquipment.Domain.Entities;

namespace HostingProcessEquipment.Application.Interfaces;

public interface IEquipmentTypeRepository 
{
    Task<ProcessEquipmentType?> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
}

