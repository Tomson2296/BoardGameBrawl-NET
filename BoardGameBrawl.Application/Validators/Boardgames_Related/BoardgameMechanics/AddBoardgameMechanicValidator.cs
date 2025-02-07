using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameCategories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameMechanics
{
    public class AddBoardgameMechanicValidator : AbstractValidator<BoardgameMechanicDTO>
    {
        private readonly IBoardgameMechanicsRepository _boardgameMechanicsRepository;

        public AddBoardgameMechanicValidator(IBoardgameMechanicsRepository boardgameMechanicsRepository)
        {
            _boardgameMechanicsRepository = boardgameMechanicsRepository;

            Include(new BoardgameMechanicValidator(_boardgameMechanicsRepository));

            RuleFor(category => category.Id)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
