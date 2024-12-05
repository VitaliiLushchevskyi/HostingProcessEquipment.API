using HostingProcessEquipment.Domain.Models;
using MediatR;

namespace HostingProcessEquipment.Application.Commands.Contracts.CreateContract;

public sealed record CreateContractCommand(CreateContractRequest ContractRequest): IRequest<Unit>;

