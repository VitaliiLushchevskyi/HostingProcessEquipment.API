namespace HostingProcessEquipment.Domain.Enums;
public enum InternalStatusCodes
{
    FacilityNotFound = 10001,
    EquipmentNotFound = 10002,
    NotEnoughAreaInFacility = 10003,

    EquipmentTypeCodeEmpty = 10004,
    EquipmentTypeCodeNull = 10005,
    EquipmentTypeCodeMaxLenght = 10006,

    FacilityCodeEmpty = 10007,
    FacilityCodeNull = 10008,
    FacilityCodeMaxLenght = 10009,

    EquipmentQuantityZero = 10010
}
