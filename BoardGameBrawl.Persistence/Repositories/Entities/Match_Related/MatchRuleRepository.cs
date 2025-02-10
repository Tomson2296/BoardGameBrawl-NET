using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Match_Related;
using BoardGameBrawl.Application.DTOs.Entities.Match_Related;
using BoardGameBrawl.Application.Profiles;
using BoardGameBrawl.Domain.Entities.Match_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Match_Related
{
    public class MatchRuleRepository : GenericRepository<MatchRule>, IMatchRuleRepository
    {
        private readonly IMapper _mapper;
        public MatchRuleRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IList<MatchRuleDTO>> GetMatchrulesetForBoardgame(Guid boardgameId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);

            return await _context.MatchRules
                .Where(r => r.BoardgameId == boardgameId)
                .ProjectTo<MatchRuleDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}