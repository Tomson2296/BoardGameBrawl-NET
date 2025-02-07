using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Boardgames_Related.Boardgames
{
    public class AddBoardgameValidator : AbstractValidator<BoardgameDTO>
    {
        private readonly IBoardgameRepository _boardgameRepository;

        public AddBoardgameValidator(IBoardgameRepository boardgameRepository)
        {
            _boardgameRepository = boardgameRepository;

            Include(new BoardgameValidator(_boardgameRepository));

            RuleFor(boardgame => boardgame.Id)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
