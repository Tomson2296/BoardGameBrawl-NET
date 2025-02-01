using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using FluentValidation;

namespace BoardGameBrawl.Application.Validators.Player_Related
{
    public class AddPlayerValidator : AbstractValidator<PlayerDTO>
    {
        private readonly IPlayerRepository _playerRepository;

        public AddPlayerValidator(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;

            Include(new PlayerValidator(_playerRepository));

            RuleFor(player => player.Id)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
