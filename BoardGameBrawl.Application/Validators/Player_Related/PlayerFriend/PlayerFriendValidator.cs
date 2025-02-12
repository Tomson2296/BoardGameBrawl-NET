using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.PlayerFriend
{
    public class PlayerFriendValidator : AbstractValidator<PlayerFriendDTO>
    {
        public PlayerFriendValidator()
        {
            RuleFor(pf => pf.RequesterName)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty")
               .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(pf => pf.AddresseeName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(pf => pf.FriendshipDate)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(pf => pf.Status)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

        }
    }
}
