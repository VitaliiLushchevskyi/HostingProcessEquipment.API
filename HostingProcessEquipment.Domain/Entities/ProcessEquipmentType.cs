namespace HostingProcessEquipment.Domain.Entities;

public class ProcessEquipmentType
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public double Area { get; set; }

    public ProcessEquipmentType(string code, string name, double area)
    {
        Code = code;
        Name = name;
        Area = area;
    }

    private ProcessEquipmentType() { }
}