using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using FluentValidation;

namespace BoardGameBrawl.Application.Validators.Group_Related.Groups
{
    public class GroupValidator : AbstractValidator<GroupDTO>
    {
        private readonly IGroupRepository _groupRepository;

        public GroupValidator(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;

            RuleFor(group => group.GroupName)
              .NotNull()
              .NotEmpty().WithMessage("{PropertyName} cannot be empty")
              .MaximumLength(256).WithMessage("Username cannot be over {ComparisonValue} characters long");

            RuleFor(group => group.GroupDescription)
              .MaximumLength(2048)
              .WithMessage("Username cannot be over {ComparisonValue} characters long")
              .When(group => !string.IsNullOrWhiteSpace(group.GroupDescription));
        }
    }
}
