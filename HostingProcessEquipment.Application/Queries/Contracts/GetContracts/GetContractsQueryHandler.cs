using HostingProcessEquipment.Application.Interfaces;
using HostingProcessEquipment.Domain.DTOs;
using MediatR;

namespace HostingProcessEquipment.Application.Queries.Contracts.GetContracts;

internal sealed class GetContractsQueryHandler(IContractRepository contractRepository) : IRequestHandler<GetContractsQuery, List<ContractDto>>
{
    public async Task<List<ContractDto>> Handle(GetContractsQuery request, CancellationToken cancellationToken)
    {
        var contracts = await contractRepository.GetContractsAsync(cancellationToken);

        var contractDtos = new List<ContractDto>();
        foreach (var contract in contracts)
        {
            contractDtos.Add(new ContractDto
            {
                ProductionFacilityName = contract.ProductionFacility.Name,
                ProcessEquipmentTypeName = contract.ProcessEquipmentType.Name,
                EquipmentQuantity = contract.EquipmentQuantity
            });
        }

        return contractDtos;
    }
}

