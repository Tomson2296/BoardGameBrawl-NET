using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Boardgames_Related.Boardgames
{
    public class BoardgameValidator : AbstractValidator<BoardgameDTO>
    {
        private readonly IBoardgameRepository _boardgameRepository;

        public BoardgameValidator(IBoardgameRepository boardgameRepository)
        {
            _boardgameRepository = boardgameRepository;

            RuleFor(boardgame => boardgame.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(256).WithMessage("{PropertyName} cannot be over {ComparisonValue} characters long");

            RuleFor(boardgame => boardgame.BGGId)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .GreaterThan(0).WithMessage("{PropertyName} need to have BGG Catalog id number higher than {ComparisonValue}");

            RuleFor(boardgame => boardgame.YearPublished)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(boardgame => boardgame.MinPlayers)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(boardgame => boardgame.MaxPlayers)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(boardgame => boardgame.PlayingTime)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(boardgame => boardgame.MinimumPlayingTime)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(boardgame => boardgame.MaximumPlayingTime)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(boardgame => boardgame.AverageBGGWeight)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(boardgame => boardgame.AverageRating)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(boardgame => boardgame.BayesRating)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(boardgame => boardgame.Owned)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(boardgame => boardgame.Image)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(boardgame => boardgame.Description)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
