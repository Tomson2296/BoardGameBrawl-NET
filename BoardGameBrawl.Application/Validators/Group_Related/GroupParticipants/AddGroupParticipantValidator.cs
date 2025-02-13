using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Group_Related.GroupParticipants
{
    public class AddGroupParticipantValidator : AbstractValidator<GroupParticipantDTO>
    {
        public AddGroupParticipantValidator()
        {
            Include(new GroupParticipantValidator());

            RuleFor(group => group.GroupId)
              .NotNull()
              .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(group => group.PlayerId)
              .NotNull()
              .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
