using HostingProcessEquipment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HostingProcessEquipment.Infrastructure.Configurations;

public class EquipmentPlacementContractConfiguration : IEntityTypeConfiguration<EquipmentPlacementContract>
{
    public void Configure(EntityTypeBuilder<EquipmentPlacementContract> builder)
    {
        builder.HasKey(epc => epc.Id);

        builder.Property(epc => epc.EquipmentQuantity)
            .IsRequired();

        builder.HasOne(epc => epc.ProductionFacility)
            .WithMany(pf => pf.Contracts)
            .HasForeignKey(epc => epc.ProductionFacilityId);

        builder.HasOne(epc => epc.ProcessEquipmentType)
            .WithMany()
            .HasForeignKey(epc => epc.ProcessEquipmentTypeId);
    }
}