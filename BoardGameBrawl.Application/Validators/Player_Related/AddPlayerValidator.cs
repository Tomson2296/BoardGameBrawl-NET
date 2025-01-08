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
