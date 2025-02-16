using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using FluentValidation;
using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.Schedule_Related.TimeSlotValidators
{
    public class TimeSlotValidator : AbstractValidator<TimeSlotDTO>
    {
        public TimeSlotValidator()
        {
            RuleSet("Default", () =>
            {
                RuleFor(slot => slot.DailyAvailabilityId)
                   .NotNull()
                   .NotEmpty()
                   .WithMessage("{PropertyName} cannot be empty");


                RuleFor(slot => slot.StartTime)
                    .NotNull()
                    .WithMessage("{PropertyName} cannot be empty");


                RuleFor(slot => slot.StartTime)
                    .LessThan(slot => slot.EndTime)
                    .WithMessage("Start time must be before end time.");


                RuleFor(slot => slot.EndTime)
                    .NotNull()
                    .WithMessage("{PropertyName} cannot be empty");
            });
        }
    }
}