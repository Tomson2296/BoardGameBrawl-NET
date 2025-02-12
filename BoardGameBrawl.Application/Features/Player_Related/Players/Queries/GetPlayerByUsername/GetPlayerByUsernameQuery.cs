using BoardGameBrawl.Application.DTOs.Entities.Player_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetPlayerByUsername
{
    public class GetPlayerByUsernameQuery : IRequest<PlayerDTO>
    {
        public string? Username { get; set; }
    }
}
