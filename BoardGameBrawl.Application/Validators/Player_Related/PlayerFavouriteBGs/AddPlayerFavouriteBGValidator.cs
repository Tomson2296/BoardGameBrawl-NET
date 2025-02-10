using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.PlayerFavouriteBGs
{
    public class AddPlayerFavouriteBGValidator : AbstractValidator<PlayerFavouriteBGDTO>
    {
        public AddPlayerFavouriteBGValidator()
        {
            Include(new PlayerFavouriteBGValidator());

            RuleFor(pp => pp.PlayerId)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} cannot be empty");

            RuleFor(pp => pp.BoardgameId)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} cannot be empty");
        }
    }
}
