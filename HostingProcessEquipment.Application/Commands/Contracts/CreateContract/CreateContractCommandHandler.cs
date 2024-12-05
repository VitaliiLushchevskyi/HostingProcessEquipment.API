using HostingProcessEquipment.Application.Interfaces;
using HostingProcessEquipment.Domain.Entities;
using HostingProcessEquipment.Domain.Enums;
using HostingProcessEquipment.Domain.Exceptions;
using MediatR;

namespace HostingProcessEquipment.Application.Commands.Contracts.CreateContract;

internal sealed class CreateContractCommandHandler(
    IContractRepository contractRepository, 
    IEquipmentTypeRepository equipmentTypeRepository, 
    IProductionFacilityRepository productionFacilityRepository) : IRequestHandler<CreateContractCommand, Unit>
{
    public async Task<Unit> Handle(CreateContractCommand command, CancellationToken cancellationToken)
    {
        var facility = await productionFacilityRepository.GetByCodeAsync(command.ContractRequest.FacilityCode, cancellationToken);
        if (facility == null)
            throw new ApiException(500, (int)InternalStatusCodes.FacilityNotFound);

        var equipment = await equipmentTypeRepository.GetByCodeAsync(command.ContractRequest.EquipmentTypeCode, cancellationToken);
        if (equipment == null)
            throw new ApiException(500, (int)InternalStatusCodes.EquipmentNotFound);

        var requiredArea = command.ContractRequest.EquipmentQuantity * equipment.Area;
        if (requiredArea > facility.StandardArea)
            throw new ApiException(500, (int)InternalStatusCodes.NotEnoughAreaInFacility);

        var contract = new EquipmentPlacementContract(
              facility.Id,
              equipment.Id,
              command.ContractRequest.EquipmentQuantity
          );

        await contractRepository.AddAsync(contract, cancellationToken);
        return Unit.Value;
    }

}

