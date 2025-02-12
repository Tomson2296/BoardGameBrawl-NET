using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.PlayerFriend
{
    public class AddPlayerFriendValidator : AbstractValidator<PlayerFriendDTO>
    {
        public AddPlayerFriendValidator()
        {
            Include(new PlayerFriendValidator());

            RuleFor(pp => pp.RequesterId)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyName} cannot be empty");

            RuleFor(pp => pp.AddresseeId)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} cannot be empty");
        }
    }
}
