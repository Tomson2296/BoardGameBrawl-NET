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
    public class BoardgameCategoryValidator : AbstractValidator<BoardgameCategoryDTO>
    {
        private readonly IBoardgameCategoriesRepository _boardgameCategoriesRepository;

        public BoardgameCategoryValidator(IBoardgameCategoriesRepository boardgameCategoriesRepository)
        {
            _boardgameCategoriesRepository = boardgameCategoriesRepository;

            RuleFor(category => category.Category)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty")
                .MaximumLength(256).WithMessage("{PropertyName} cannot be over {ComparisonValue} characters long");
        }
    }
}
