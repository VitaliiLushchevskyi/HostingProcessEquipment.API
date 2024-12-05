using HostingProcessEquipment.Domain.DTOs;
using MediatR;

namespace HostingProcessEquipment.Application.Queries.Contracts.GetContracts;

public sealed record GetContractsQuery() : IRequest<List<ContractDto>>;
