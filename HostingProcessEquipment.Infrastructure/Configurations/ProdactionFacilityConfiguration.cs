using HostingProcessEquipment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HostingProcessEquipment.Infrastructure.Configurations;
public class ProductionFacilityConfiguration : IEntityTypeConfiguration<ProductionFacility>
{
    public void Configure(EntityTypeBuilder<ProductionFacility> builder)
    {
        builder.HasKey(pf => pf.Id);

        builder.Property(pf => pf.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(pf => pf.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(pf => pf.StandardArea)
            .IsRequired();

        builder.HasMany(pf => pf.Contracts)
            .WithOne(c => c.ProductionFacility)
            .HasForeignKey(c => c.ProductionFacilityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}