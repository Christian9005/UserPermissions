using FluentValidation;

using UserPermissions.Application.Permissions.Commands;

namespace UserPermissions.Application.Permissions.Validators;

public class CreatePermissionValidator : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("El apellido es obligatorio");

        RuleFor(x => x.PermissionTypeId)
            .GreaterThan(0).WithMessage("TipoPermisoId debe ser mayor que 0");

        RuleFor(x => x.PermissionDate)
            .NotEmpty().WithMessage("La fecha es obligatoria");
    }
}
