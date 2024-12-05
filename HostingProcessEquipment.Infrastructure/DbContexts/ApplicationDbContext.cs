using HostingProcessEquipment.Domain.Entities;
using HostingProcessEquipment.Infrastructure.Configurations;
using HostingProcessEquipment.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace HostingProcessEquipment.Infrastructure.DbContexts;
public class ApplicationDbContext : DbContext
{
    public DbSet<ProductionFacility> ProductionFacilities { get; set; }
    public DbSet<ProcessEquipmentType> ProcessEquipmentTypes { get; set; }
    public DbSet<EquipmentPlacementContract> EquipmentPlacementContracts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProductionFacilityConfiguration());
        modelBuilder.ApplyConfiguration(new ProcessEquipmentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new EquipmentPlacementContractConfiguration());

        InitialSeeds.Seed(modelBuilder);
    }
}

