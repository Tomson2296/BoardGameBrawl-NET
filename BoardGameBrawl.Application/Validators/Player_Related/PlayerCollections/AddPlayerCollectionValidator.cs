using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.PlayerCollections
{
    public class AddPlayerCollectionValidator : AbstractValidator<PlayerCollectionDTO>
    {
        public AddPlayerCollectionValidator()
        {
            Include(new PlayerCollectionValidator());

            RuleFor(pc => pc.PlayerId)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be null or empty");
        }
    }
}
