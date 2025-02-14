using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Player_Related.PlayerSchedule.Queries.CheckIfPlayerScheduleExists
{
    public class CheckIfPlayerScheduleExistsQuery : IRequest<bool>
    {
        public Guid PlayerId { get; set; }
    }
}
