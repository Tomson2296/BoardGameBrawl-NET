using BoardGameBrawl.Application.Contracts.Entities.Player_Related;
using BoardGameBrawl.Application.DTOs.Entities.Player_Related.Preference_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Player_Related.PlayerPreferences
{
    public class UpdatePlayerPreferenceValidator : AbstractValidator<PlayerPreferenceDTO>
    {
        private readonly IPlayerPreferenceRepository playerPreferenceRepository;

        public UpdatePlayerPreferenceValidator(IPlayerPreferenceRepository playerPreferenceRepository)
        {
            this.playerPreferenceRepository = playerPreferenceRepository;

            Include(new PlayerPreferenceValidator());

            // Validate the composite key as a single rule
            RuleFor(x => x)
                .MustAsync(async (request, cancellationToken) =>
                    await playerPreferenceRepository.Exists(request.PlayerId, request.BoardgameId, cancellationToken))
                .WithMessage("Entity with PlayerId {PlayerId} and BoardgameId {BoardgameId} does not exist.");
        }
    }
}
