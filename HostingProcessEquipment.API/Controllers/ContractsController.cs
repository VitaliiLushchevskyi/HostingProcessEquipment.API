using HostingProcessEquipment.Application.Commands.Contracts.CreateContract;
using HostingProcessEquipment.Application.Queries.Contracts.GetContracts;
using HostingProcessEquipment.Domain.DTOs;
using HostingProcessEquipment.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HostingProcessEquipment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractsController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ContractDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> GetContracts(CancellationToken cancellationToken)
    {
       var contracts = await mediator.Send(new GetContractsQuery(), cancellationToken);
       return Ok(contracts);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> CreateContract([FromBody] CreateContractRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new CreateContractCommand(request), cancellationToken);
        return Ok();
    }
}

