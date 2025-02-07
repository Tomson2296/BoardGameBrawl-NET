﻿using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameCategoryTags
{
    public class AddBoardgameCategoryTagsValidator : AbstractValidator<BoardgameCategoryTagDTO>
    {
        private readonly IBoardgameCategoryTagsRepository _boardgameCategoryTagsRepository;

        public AddBoardgameCategoryTagsValidator(IBoardgameCategoryTagsRepository boardgameCategoryTagsRepository)
        {
            _boardgameCategoryTagsRepository = boardgameCategoryTagsRepository;

            RuleFor(tag => tag.BoardgameId)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty");

            RuleFor(tag => tag.CategoryId)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
