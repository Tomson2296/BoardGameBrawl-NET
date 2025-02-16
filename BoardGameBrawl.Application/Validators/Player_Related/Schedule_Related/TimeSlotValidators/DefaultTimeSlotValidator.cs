using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.Schedule_Related.TimeSlotValidators
{
    public class DefaultTimeSlotValidator : AbstractValidator<TimeSlotDTO>
    {
        public DefaultTimeSlotValidator()
        {
            RuleFor(slot => slot.DailyAvailabilityId)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty");

            RuleFor(slot => slot.StartTime)
                .NotNull()
                .WithMessage("{PropertyName} cannot be empty");

            RuleFor(slot => slot.EndTime)
                .NotNull()
                .WithMessage("{PropertyName} cannot be empty");
        }
    }
}
