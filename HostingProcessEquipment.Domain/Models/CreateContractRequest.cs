namespace HostingProcessEquipment.Domain.Models;

public class CreateContractRequest
{
    public string FacilityCode { get; set; }
    public string EquipmentTypeCode { get; set; }
    public int EquipmentQuantity { get; set; }
}

