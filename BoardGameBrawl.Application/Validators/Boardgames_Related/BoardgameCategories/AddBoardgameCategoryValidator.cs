using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameCategories
{
    public class AddBoardgameCategoryValidator : AbstractValidator<BoardgameCategoryDTO>
    {
        private readonly IBoardgameCategoriesRepository _boardgameCategoriesRepository;

        public AddBoardgameCategoryValidator(IBoardgameCategoriesRepository boardgameCategoriesRepository)
        {
            _boardgameCategoriesRepository = boardgameCategoriesRepository;

            Include(new BoardgameCategoryValidator(_boardgameCategoriesRepository));

            RuleFor(boardgame => boardgame.Id)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
