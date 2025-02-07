#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameDomains.Commands.AddBoardgameDomain
{
    public class AddBoardgameDomainCommand : IRequest<BaseCommandResponse>
    {
        public BoardgameDomainDTO BoardgameDomainDTO { get; set; }  
    }
}
