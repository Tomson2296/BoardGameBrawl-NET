using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Schedule_Related;
using BoardGameBrawl.Application.Validators.Player_Related.Schedule_Related.DailyAvailabilityValidators;
using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.Schedule_Related.PlayerScheduleValidators
{
    public class PlayerScheduleValidator : AbstractValidator<PlayerScheduleDTO>
    {
        public PlayerScheduleValidator()
        {
            RuleSet("Default", () =>
            {
                RuleFor(schedule => schedule.Id)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyName} cannot be empty");

                RuleFor(schedule => schedule.PlayerId)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("{PropertyName} cannot be empty");

                RuleForEach(schedule => schedule.DailyAvailabilities)
                    .SetValidator(new DailyAvailabilityValidator());
            });


            RuleSet("Creation", () =>
            {
                RuleFor(schedule => schedule.Id)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage("{PropertyName} cannot be empty");

                RuleFor(schedule => schedule.PlayerId)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("{PropertyName} cannot be empty");

                RuleForEach(schedule => schedule.DailyAvailabilities)
                    .SetValidator(new DailyAvailabilityValidator());
            });

        }
    }
}
