using FluentValidation;
using HostingProcessEquipment.Application.Validators;
using HostingProcessEquipment.Domain.Enums;

namespace HostingProcessEquipment.Application.Commands.Contracts.CreateContract;

public class CreateContractCommandValidator : BaseValidator<CreateContractCommand>
{
    public CreateContractCommandValidator()
    {
        RuleFor(command => command.ContractRequest.EquipmentTypeCode)
            .NotEmpty().WithErrorCode(((int)InternalStatusCodes.EquipmentTypeCodeEmpty).ToString())
            .NotNull().WithErrorCode(((int)InternalStatusCodes.EquipmentTypeCodeNull).ToString())
            .MaximumLength(50).WithErrorCode(((int)InternalStatusCodes.EquipmentTypeCodeMaxLenght).ToString());


        RuleFor(command => command.ContractRequest.FacilityCode)
            .NotEmpty().WithErrorCode(((int)InternalStatusCodes.FacilityCodeEmpty).ToString())
            .NotNull().WithErrorCode(((int)InternalStatusCodes.FacilityCodeNull).ToString())
            .MaximumLength(50).WithErrorCode(((int)InternalStatusCodes.FacilityCodeMaxLenght).ToString());

        RuleFor(command => command.ContractRequest.EquipmentQuantity)
              .GreaterThan(0).WithErrorCode(((int)InternalStatusCodes.EquipmentQuantityZero).ToString());
    }
}