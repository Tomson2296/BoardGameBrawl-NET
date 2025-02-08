using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.PlayerPreferences
{
    public class PlayerPreferenceValidator : AbstractValidator<PlayerPreferenceDTO>
    {
        public PlayerPreferenceValidator()
        {
            RuleFor(player => player.PlayerName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(pp => pp.BoardgameName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(pp => pp.Rating)
                .NotNull()
                .WithMessage("{PropertyName} cannot be null");
        }
    }
}
