using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Match_Related
{
    public class MatchRuleValidator : AbstractValidator<MatchRuleDTO>
    {
        public MatchRuleValidator()
        {
            RuleFor(rule => rule.RuleDescription)
             .NotNull()
             .NotEmpty().WithMessage("{PropertyName} cannot be empty")
             .MaximumLength(512).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(rule => rule.RuleType)
              .NotNull()
              .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
