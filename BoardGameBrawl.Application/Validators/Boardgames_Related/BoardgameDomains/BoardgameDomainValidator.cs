using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Validators.Boardgames_Related.BoardgameDomains
{
    public class BoardgameDomainValidator : AbstractValidator<BoardgameDomainDTO>
    {
        private readonly IBoardgameDomainsRepository _boardgameDomainsRepository;

        public BoardgameDomainValidator(IBoardgameDomainsRepository boardgameDomainsRepository)
        {
            _boardgameDomainsRepository = boardgameDomainsRepository;

            RuleFor(domain => domain.Domain)
               .NotNull()
               .NotEmpty().WithMessage("{PropertyName} cannot be empty")
               .MaximumLength(256).WithMessage("{PropertyName} cannot be over {ComparisonValue} characters long");
        }
    }
}
