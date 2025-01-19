using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using FluentValidation;

namespace BoardGameBrawl.Application.Validators.Group_Related
{
    public class AddGroupValidator : AbstractValidator<GroupDTO>
    {
        private readonly IGroupRepository _groupRepository;

        public AddGroupValidator(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;

            Include(new GroupValidator(groupRepository));

            RuleFor(group => group.Id)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
