using AutoMapper;
using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Generic.Queries.CheckIfJunctionEntityExists
{
    public abstract class CheckIfJunctionEntityExistsQueryHandler<TCommand, TEntityDTO, TEntity> : IRequestHandler<TCommand, bool>
        where TCommand : IRequest<bool>
        where TEntityDTO : class
        where TEntity : class
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;

        protected CheckIfJunctionEntityExistsQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(TCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var dto = GetEntityDTOFromRequest(request);
            var entity = _mapper.Map<TEntity>(_mapper.ConfigurationProvider);
            var repo = GetRepository(_unitofWork);
            var primaryKeys = repo.GetPrimaryKeys(entity, cancellationToken).Result;
            return await repo.Exists(primaryKeys, cancellationToken);
        }

        protected abstract TEntityDTO GetEntityDTOFromRequest(TCommand command);
        protected abstract IGenericRepository<TEntity> GetRepository(IUnitOfWork unitOfWork);
    }
}
