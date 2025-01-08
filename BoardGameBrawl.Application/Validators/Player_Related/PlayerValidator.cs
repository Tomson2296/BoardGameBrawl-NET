using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using FluentValidation;

namespace BoardGameBrawl.Application.Validators.Player_Related
{
    public class PlayerValidator : AbstractValidator<PlayerDTO>
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerValidator(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;

            RuleFor(player => player.UserName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(player => player.Email)
               .EmailAddress()
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty")
               .MaximumLength(256).WithMessage("{PropertyName} cannot be over {ComparisonValue} characters long");

            RuleFor(player => player.FirstName)
               .MaximumLength(256).WithMessage("{PropertyName} cannot be over {ComparisonValue} characters long");

            RuleFor(player => player.LastName)
               .MaximumLength(256).WithMessage("{PropertyName} cannot be over {ComparisonValue} characters long");

            RuleFor(player => player.BGGUsername)
               .MaximumLength(256).WithMessage("{PropertyName} cannot be over {ComparisonValue} characters long");

            RuleFor(player => player.UserDescription)
               .MaximumLength(512).WithMessage("{PropertyName} cannot be over {ComparisonValue} characters long");
        }
    }
}
