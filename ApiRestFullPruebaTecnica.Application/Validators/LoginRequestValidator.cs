using ApiRestFullPruebaTecnica.Application.DTOs.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestFullPruebaTecnica.Application.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio")
                .MaximumLength(25).WithMessage("El nombre de usuario no puede tener mas de 25 caracteres");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria")
                .MinimumLength(6).WithMessage("La contraseña debe tener minimo 6 caracteres");
        }
    }
}
