namespace HostingProcessEquipment.Domain.Entities;

public class EquipmentPlacementContract
{
    public Guid Id { get; set; }
    public Guid ProductionFacilityId { get; set; }
    public ProductionFacility? ProductionFacility { get; set; }

    public Guid ProcessEquipmentTypeId { get; set; }
    public ProcessEquipmentType? ProcessEquipmentType { get; set; }

    public int EquipmentQuantity { get; set; }

    public EquipmentPlacementContract(Guid productionFacilityId, Guid processEquipmentTypeId, int equipmentQuantity)
    {
        ProductionFacilityId = productionFacilityId;
        ProcessEquipmentTypeId = processEquipmentTypeId;
        EquipmentQuantity = equipmentQuantity;
    }

    private EquipmentPlacementContract() { }
}