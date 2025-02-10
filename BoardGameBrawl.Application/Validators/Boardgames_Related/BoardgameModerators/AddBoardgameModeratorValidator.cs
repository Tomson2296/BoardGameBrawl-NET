using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameModerators
{
    public class AddBoardgameModeratorValidator : AbstractValidator<BoardgameModeratorDTO>
    {
        public AddBoardgameModeratorValidator()
        {
            Include(new BoardgameModeratorValidator());

            RuleFor(mod => mod.ModeratorId)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(mod => mod.BoardgameId)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
