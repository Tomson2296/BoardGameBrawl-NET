using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Match_Related
{
    public class AddMatchRuleValidator : AbstractValidator<MatchRuleDTO>
    {
        public AddMatchRuleValidator()
        {
            Include(new MatchRuleValidator());

            RuleFor(rule => rule.RuleId)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(rule => rule.BoardgameId)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
