#nullable disable
using BoardGameBrawl.Application.DTOs.Entities.Group_Related;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Group_Related.Group.Queries.GetFilteredBatchOfGroups
{
    public class GetFilteredBatchOfGroupsQuery : IRequest<IList<NavGroupDTO>>
    {
        public string Filter { get; set; }

        public int Size { get; set; }

        public int Skip { get; set; }
    }
}
