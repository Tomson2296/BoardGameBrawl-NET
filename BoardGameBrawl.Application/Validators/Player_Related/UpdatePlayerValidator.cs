using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using FluentValidation;

namespace BoardGameBrawl.Application.Validators.Player_Related
{
    public class UpdatePlayerValidator : AbstractValidator<PlayerDTO>
    {
        private readonly IPlayerRepository _playerRepository;

        public UpdatePlayerValidator(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;

            Include(new PlayerValidator(_playerRepository));

            RuleFor(player => player.Id)
               .MustAsync(async (id, token) => {
                   var playerExists = await _playerRepository.Exists(id, token);
                   return playerExists;
               })
               .WithMessage("{PropertyName} does not exist.");
        }
    }
}
