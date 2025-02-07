using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameMechanicTags
{
    public class AddBoardgameMechanicTagsValidator : AbstractValidator<BoardgameMechanicTagDTO>
    {
        private readonly IBoardgameMechanicTagsRepository _boardgameMechanicTagsRepository;

        public AddBoardgameMechanicTagsValidator(IBoardgameMechanicTagsRepository boardgameMechanicTagsRepository)
        {
            _boardgameMechanicTagsRepository = boardgameMechanicTagsRepository;

            RuleFor(tag => tag.BoardgameId)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(tag => tag.MechanicId)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
