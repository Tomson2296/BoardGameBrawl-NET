using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.PlayerFavouriteBGs
{
    public class PlayerFavouriteBGValidator : AbstractValidator<PlayerFavouriteBGDTO>
    {
        public PlayerFavouriteBGValidator()
        {
            RuleFor(pf => pf.PlayerName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(pf => pf.BoardgameName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");
        }
    }
}
