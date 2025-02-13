using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Group_Related.GroupParticipants
{
    public class GroupParticipantValidator : AbstractValidator<GroupParticipantDTO>
    {
        public GroupParticipantValidator()
        {
            RuleFor(group => group.GroupName)
             .NotNull()
             .NotEmpty().WithMessage("{PropertyName} cannot be empty")
             .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(group => group.PlayerName)
              .NotNull()
              .NotEmpty().WithMessage("{PropertyName} cannot be empty")
              .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(group => group.IsAdmin)
             .NotNull()
             .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
