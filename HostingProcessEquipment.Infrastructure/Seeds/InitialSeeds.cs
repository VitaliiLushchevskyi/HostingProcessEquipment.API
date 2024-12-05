using HostingProcessEquipment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HostingProcessEquipment.Infrastructure.Seeds;

public static class InitialSeeds
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Seed ProductionFacility
        modelBuilder.Entity<ProductionFacility>().HasData(
            new ProductionFacility("FAC001", "Main Facility", 1000.0)
            {
                Id = Guid.Parse("d3a4bdae-5f7b-4f76-8f8d-99f97843d61a")
            },
            new ProductionFacility("FAC002", "Secondary Facility", 750.0)
            {
                Id = Guid.Parse("6bc2e8ab-9289-4cb2-b0ff-2e8b8c5d4976")
            }
        );

        // Seed ProcessEquipmentType
        modelBuilder.Entity<ProcessEquipmentType>().HasData(
            new ProcessEquipmentType("EQP001", "Crusher", 150.0)
            {
                Id = Guid.Parse("f3b5e6c4-2a19-4aa4-a0c4-d73f66a758a1")
            },
            new ProcessEquipmentType("EQP002", "Conveyor Belt", 100.0)
            {
                Id = Guid.Parse("bb2d4866-8516-4c15-8143-cd8a857dab43")
            }
        );

        // Seed EquipmentPlacementContract
        modelBuilder.Entity<EquipmentPlacementContract>().HasData(
            new EquipmentPlacementContract(
                productionFacilityId: Guid.Parse("d3a4bdae-5f7b-4f76-8f8d-99f97843d61a"),
                processEquipmentTypeId: Guid.Parse("f3b5e6c4-2a19-4aa4-a0c4-d73f66a758a1"),
                equipmentQuantity: 5
            )
            {
                Id = Guid.Parse("2a941d10-8b69-4b07-b5f1-0b8fd7ea5883")
            },
            new EquipmentPlacementContract(
                productionFacilityId: Guid.Parse("6bc2e8ab-9289-4cb2-b0ff-2e8b8c5d4976"),
                processEquipmentTypeId: Guid.Parse("bb2d4866-8516-4c15-8143-cd8a857dab43"),
                equipmentQuantity: 3
            )
            {
                Id = Guid.Parse("c5a0df62-9534-4df9-8499-912dcb555b9e")
            }
        );
    }
}

