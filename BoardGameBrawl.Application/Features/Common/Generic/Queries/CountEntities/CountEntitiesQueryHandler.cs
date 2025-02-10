using BoardGameBrawl.Application.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Application.Features.Common.Queries.CountEntities
{
    public abstract class CountEntitiesQueryHandler<TCommand, TEntity> : IRequestHandler<TCommand, int>
        where TCommand : IRequest<int>
        where TEntity : class
    {
        private readonly IUnitOfWork unitOfWork;

        protected CountEntitiesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var repo = GetRepository(unitOfWork);

            return await repo.CountTotalElements(cancellationToken);
        }

        protected abstract IGenericRepository<TEntity> GetRepository(IUnitOfWork unitOfWork);
    }
}
