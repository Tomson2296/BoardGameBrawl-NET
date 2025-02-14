using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Application.Validators.Player_Related.Schedule_Related.TimeSlotValidators;
using BoardGameBrawl.Domain.Entities.Player_Related.Schedule_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.Schedule_Related.DailyAvailabilityValidators
{
    public class DailyAvailabilityValidator : AbstractValidator<DailyAvailabilityDTO>
    {
        public DailyAvailabilityValidator()
        {
            RuleSet("Default", () =>
            {
                RuleFor(slot => slot.PlayerScheduleId)
                   .NotNull()
                   .NotEmpty()
                   .WithMessage("{PropertyName} cannot be empty");

                RuleFor(daily => daily.DayOfWeek)
                    .IsInEnum()
                    .WithMessage("{PropertyName} must be a valid day of the week");

                RuleForEach(da => da.TimeSlots)
                    .SetValidator(new TimeSlotValidator());
            });


            RuleSet("Creation", () =>
            {
                RuleFor(slot => slot.PlayerScheduleId)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyName} cannot be empty");

                RuleFor(daily => daily.DayOfWeek)
                   .IsInEnum()
                   .WithMessage("{PropertyName} must be a valid day of the week");
            });
        }
    }
}