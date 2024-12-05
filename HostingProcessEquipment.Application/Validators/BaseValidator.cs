using FluentValidation;

namespace HostingProcessEquipment.Application.Validators;

public abstract class BaseValidator<T> : AbstractValidator<T>
{
    protected BaseValidator() => CascadeMode = CascadeMode.Stop;
}

