using MediatR;

namespace BoardGameBrawl.Application.Features.Player_Related.Players.Queries.GetAllPlayerPreferences
{
    public class GetAllPlayerPreferncesQuery : IRequest<IDictionary<Guid, byte>>
    {
        public Guid PlayerId { get; set; }
    }
}
