using FluentValidation;
using GestaoMaquiesse.Domain.Entidades;

namespace GestaoMaquiesse.Domain.Validador
{
    public class ValidadorUsuario : AbstractValidator<Usuario>
    {
        public ValidadorUsuario(){
            RuleFor(x=>x)
                .NotEmpty()
                .WithMessage("A entidade não Pode estar Vazia")

                .NotNull()
                .WithMessage("A entidade não pode ser nula");
            RuleFor(x=>x.Nome)
                .NotNull()
                .WithMessage("O Nome não pode ser nulo")

                .NotEmpty()
                .WithMessage("O nome não pode ser Vazio")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 Caracteres")

                .MaximumLength(80)
                .WithMessage("O nome deve ter 80 Caracteres no máximo");
            RuleFor(x=>x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo")

                .NotEmpty()
                .WithMessage("O Email não pode ser vazio")

                .MinimumLength(10)
                .WithMessage("O email deve ter no mínimo 10 caracteres")

                .MaximumLength(180)
                .WithMessage("O email deve ter no máximo 180 caracteres");

            RuleFor(x=>x.PalavraPasse)
                .NotNull()
                .WithMessage("A palavra Passe não pode ser nulo")

                .NotEmpty()
                .WithMessage("A palavra passe não pode ser vazia")

                .MinimumLength(6)
                .WithMessage("A palavra passe deve ter no mínimo 8 caracteres")

                .MaximumLength(30)
                .WithMessage("A Palavra passe deve ter no máximo 80 Caracteres");
        }
    }
}