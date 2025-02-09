using AutoMapper;
using AutoMapper.QueryableExtensions;
using BoardGameBrawl.Application.Contracts.Entities.Boardgames_Related;
using BoardGameBrawl.Application.DTOs.Entities.Boardgame_Related;
using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using BoardGameBrawl.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.Repositories.Entities.Boardgame_Related
{
    public class BoardgameDomainTagsRepository : GenericRepository<BoardgameDomainTag>, IBoardgameDomainTagsRepository
    {
        private readonly IMapper _mapper;
        public BoardgameDomainTagsRepository(MainAppDBContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        // custom methods //


        public async Task<bool> Exists(Guid boardgameId,
            Guid domainId,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);
            ArgumentNullException.ThrowIfNull(domainId);

            var entity = await Context.Set<BoardgameDomainTag>().FindAsync(new[] { boardgameId, domainId }, cancellationToken);
            return entity != null;
        }


        // getter methods //

        public async Task<BoardgameDomainTag?> GetEntity(Guid boardgameId,
          Guid domainId,
          CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);
            ArgumentNullException.ThrowIfNull(domainId);

            return await _context.Set<BoardgameDomainTag>().FindAsync(new[] { boardgameId, domainId }, cancellationToken);
        }

        public async Task<IList<BoardgameDomainDTO>> GetBoardgameDomainsByBoardgameIdAsync(Guid boardgameId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(boardgameId);

            //var query = from domains in Context.BoardgameDomains
            //            join boardgameDomains in Context.BoardgameDomainTags
            //            on domains.Id equals boardgameDomains.DomainId
            //            where boardgameDomains.BoardgameId == boardgameId
            //            select domains;

            return await _context.BoardgameDomains
                .Where(bg => bg.BoardgameDomainTags!.Any(bd => bd.BoardgameId == boardgameId))
                .ProjectTo<BoardgameDomainDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<NavBoardgameDTO>> GetBoardgamesByDomainAsync(Guid domainId, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(domainId);

            //var query = from boardgames in Context.Boardgames
            //            join boardgameDomains in Context.BoardgameDomainTags
            //            on boardgames.Id equals boardgameDomains.BoardgameId
            //            where boardgameDomains.DomainId == domainId
            //            select boardgames;

            return await _context.Boardgames
                .Where(b => b.BoardgameDomainTags!.Any(bd => bd.DomainId == domainId))
                .ProjectTo<NavBoardgameDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<IList<NavBoardgameDTO>> GetBatchOfBoardgamesByDomainAsync(Guid domainId, int size, int skip = 0, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ArgumentNullException.ThrowIfNull(domainId);

            if (size <= 0)
                throw new ArgumentException("Batch size must be greater than zero.", nameof(size));

            try
            {
                return await _context.Boardgames
                    .Where(b => b.BoardgameDomainTags!.Any(bd => bd.DomainId == domainId))
                    .OrderBy(b => b.Name)
                    .ProjectTo<NavBoardgameDTO>(_mapper.ConfigurationProvider)
                    .Skip(skip)
                    .Take(size)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving a batch of entities.", ex);
            }
        }
    }
}
