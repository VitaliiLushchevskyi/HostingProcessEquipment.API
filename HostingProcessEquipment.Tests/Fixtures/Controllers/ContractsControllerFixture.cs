using AutoFixture;
using HostingProcessEquipment.API.Controllers;
using MediatR;
using Moq;

namespace HostingProcessEquipment.Tests.Fixtures.Controllers;

public class ContractsControllerFixture
{
    public Mock<IMediator> MediatorMock { get; }
    public ContractsController Controller { get; }
    public Fixture Fixture { get; }

    public ContractsControllerFixture()
    {
        MediatorMock = new Mock<IMediator>();
        Controller = new ContractsController(MediatorMock.Object);
        Fixture = new Fixture();
    }
}