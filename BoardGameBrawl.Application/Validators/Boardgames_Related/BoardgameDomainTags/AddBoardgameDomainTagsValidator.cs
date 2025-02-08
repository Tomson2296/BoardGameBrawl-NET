using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameDomainTags
{
    public class AddBoardgameDomainTagsValidator : AbstractValidator<BoardgameDomainTagDTO>
    {
        public AddBoardgameDomainTagsValidator()
        {
            RuleFor(tag => tag.BoardgameId)
              .NotNull()
              .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(tag => tag.BoardgameName)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty")
               .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(tag => tag.DomainId)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(tag => tag.DomainName)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty")
               .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");
        }
    }
}
