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
    public class UpdateBoardgameValidator : AbstractValidator<BoardgameDTO>
    {
        private readonly IBoardgameRepository _boardgameRepository;

        public UpdateBoardgameValidator(IBoardgameRepository boardgameRepository)
        {
            _boardgameRepository = boardgameRepository;

            Include(new BoardgameValidator(_boardgameRepository));

            RuleFor(boardgame => boardgame.Id)
               .MustAsync(async (id, token) =>
               {
                   var boardgameExists = await _boardgameRepository.Exists(id, token);
                   return boardgameExists;
               })
               .WithMessage("{PropertyName} does not exist.");
        }
    }
}