using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
