#nullable disable
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Boardgames_Related.BoardgameCategories.Queries.GetBoardgameCategoryId
{
    public class GetBoardgameCategoryIdQuery : IRequest<Guid>
    {
        public string CategoryName { get; set; }
    }
}
