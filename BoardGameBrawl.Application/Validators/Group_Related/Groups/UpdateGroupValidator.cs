using BoardGameBrawl.Application.Contracts.Entities.Group_Related;
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using FluentValidation;

namespace BoardGameBrawl.Application.Validators.Group_Related.Groups
{
    public class UpdateGroupValidator : AbstractValidator<GroupDTO>
    {
        private readonly IGroupRepository _groupRepository;

        public UpdateGroupValidator(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;

            Include(new GroupValidator(groupRepository));

            RuleFor(player => player.Id)
            .MustAsync(async (id, token) =>
            {
                var playerExists = await _groupRepository.Exists(id, token);
                return playerExists;
            })
            .WithMessage("{PropertyName} does not exist.");
        }
    }
}
