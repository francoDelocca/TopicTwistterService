using System.Collections.Generic;
using System.Threading.Tasks;
using TopicTwisterService.shared.Domain;

public interface IMatchRepository : IAsyncRepository<Match>
{
    public Match FindBrandNewPlayableMatch(int playerId);
    public Task<List<PendingMatchDTO>> GetListOfPendingMatches(int playerId);

    public Task<List<FinishedMatchDTO>> GetListOfFinishedMatches(int playerId);

    public Task<Match> GetFullMatch(int matchID);
}