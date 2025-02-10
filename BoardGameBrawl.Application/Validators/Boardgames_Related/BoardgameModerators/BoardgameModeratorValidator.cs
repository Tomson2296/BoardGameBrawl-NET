using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameModerators
{
    public class BoardgameModeratorValidator : AbstractValidator<BoardgameModeratorDTO>
    {
        public BoardgameModeratorValidator()
        {
            RuleFor(mod => mod.ModeratorName)
              .NotNull()
              .NotEmpty().WithMessage("{PropertyName} cannot be empty")
              .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(mod => mod.BoardgameName)
             .NotNull()
             .NotEmpty().WithMessage("{PropertyName} cannot be empty")
             .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");
        }
    }
}
