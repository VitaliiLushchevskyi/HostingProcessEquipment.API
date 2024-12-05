using HostingProcessEquipment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HostingProcessEquipment.Infrastructure.Configurations;
public class ProcessEquipmentTypeConfiguration : IEntityTypeConfiguration<ProcessEquipmentType>
{
    public void Configure(EntityTypeBuilder<ProcessEquipmentType> builder)
    {
        builder.HasKey(pe => pe.Id);

        builder.Property(pe => pe.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(pe => pe.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(pe => pe.Area)
            .IsRequired();
    }
}