namespace HostingProcessEquipment.Domain.Entities;

public class ProductionFacility
{
        public Guid Id { get;  set; }
        public string Code { get;  set; }
        public string Name { get; set; }
        public double StandardArea { get;  set; }

        public ICollection<EquipmentPlacementContract> Contracts { get;  set; }

        public ProductionFacility(string code, string name, double standardArea)
        {
            Code = code;
            Name = name;
            StandardArea = standardArea;
            Contracts = [];
        }

        private ProductionFacility() { }
}
