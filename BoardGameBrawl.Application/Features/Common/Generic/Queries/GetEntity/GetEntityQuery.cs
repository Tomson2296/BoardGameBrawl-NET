using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Generic.Queries.GetEntity
{

    /// <summary>
    /// Generic GetEntityQuery that provides functionality to get an singular entity from database
    /// </summary>
    /// <typeparam name="TEntityDTO"></typeparam>
    /// 
    public abstract class GetEntityQuery<TEntityDTO> : IRequest<TEntityDTO>
        where TEntityDTO : class
    {
        public Guid Id { get; set; }
    }
}
