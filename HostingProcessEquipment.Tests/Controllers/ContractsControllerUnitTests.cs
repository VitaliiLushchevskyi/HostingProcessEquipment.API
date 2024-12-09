using AutoFixture;
using HostingProcessEquipment.Application.Commands.Contracts.CreateContract;
using HostingProcessEquipment.Application.Queries.Contracts.GetContracts;
using HostingProcessEquipment.Domain.DTOs;
using HostingProcessEquipment.Domain.Models;
using HostingProcessEquipment.Tests.Fixtures.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HostingProcessEquipment.Tests.Controllers;

public class ContractsControllerUnitTests(ContractsControllerFixture fixture) : IClassFixture<ContractsControllerFixture>
{
    [Fact]
    public async Task GetContracts_ValidRequest_ReturnsOkWithContracts()
    {
        // Arrange
        var expectedContracts = fixture.Fixture.Create<List<ContractDto>>();
        fixture.MediatorMock
            .Setup(m => m.Send(It.IsAny<GetContractsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedContracts);

        // Act
        var result = await fixture.Controller.GetContracts(CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var contracts = Assert.IsType<List<ContractDto>>(okResult.Value);

        Assert.Equal(expectedContracts.Count, contracts.Count);
        Assert.Equal(expectedContracts[1].ProductionFacilityName, contracts[1].ProductionFacilityName);
        Assert.Equal(expectedContracts[0].ProcessEquipmentTypeName, contracts[0].ProcessEquipmentTypeName);

    }

    [Fact]
    public async Task CreateContract_ValidRequest_ReturnsOk()
    {
        // Arrange
        var createContractRequest = fixture.Fixture.Create<CreateContractRequest>();
        fixture.MediatorMock
            .Setup(m => m.Send(It.IsAny<CreateContractCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Unit.Value); 

        // Act
        var result = await fixture.Controller.CreateContract(createContractRequest, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkResult>(result); 
        fixture.MediatorMock.Verify(m => m.Send(It.IsAny<CreateContractCommand>(), It.IsAny<CancellationToken>()), Times.Once); 
    }

    
}

