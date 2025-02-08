using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.PlayerCollections
{
    public class PlayerCollectionValidator : AbstractValidator<PlayerCollectionDTO>
    {
        public PlayerCollectionValidator()
        {
            RuleFor(pc => pc.PlayerId)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} cannot be null or empty");

            RuleFor(pc => pc.PlayerName)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty")
               .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(pc => pc.BoardgameCollection)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} cannot be null or empty");
        }
    }
}
