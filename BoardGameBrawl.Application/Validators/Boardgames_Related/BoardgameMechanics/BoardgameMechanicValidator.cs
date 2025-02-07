using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameMechanics
{
    public class BoardgameMechanicValidator : AbstractValidator<BoardgameMechanicDTO>
    {
        private readonly IBoardgameMechanicsRepository _boardgameMechanicsRepository;

        public BoardgameMechanicValidator(IBoardgameMechanicsRepository boardgameMechanicsRepository)
        {
            _boardgameMechanicsRepository = boardgameMechanicsRepository;

            RuleFor(mechanic => mechanic.Mechanic)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(256).WithMessage("{PropertyName} cannot be over {ComparisonValue} characters long");
        }
    }
}
