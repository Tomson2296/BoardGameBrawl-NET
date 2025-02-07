#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomainTags.Commands.AddBoardgameDomainTag
{
    public class AddBoardgameDomainTagCommand : IRequest<BaseCommandResponse>
    {
        public BoardgameDomainTagDTO BoardgameDomainTagDTO { get; set; }
    }
}
