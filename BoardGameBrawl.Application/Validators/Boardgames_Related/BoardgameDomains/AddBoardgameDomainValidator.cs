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
    public class AddBoardgameDomainValidator : AbstractValidator<BoardgameDomainDTO>
    {
        private readonly IBoardgameDomainsRepository _boardgameDomainsRepository;

        public AddBoardgameDomainValidator(IBoardgameDomainsRepository boardgameDomainsRepository)
        {
            _boardgameDomainsRepository = boardgameDomainsRepository;

            Include(new BoardgameDomainValidator(_boardgameDomainsRepository));

            RuleFor(domain => domain.Id)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
