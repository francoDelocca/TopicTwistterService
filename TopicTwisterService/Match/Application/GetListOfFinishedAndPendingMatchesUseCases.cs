using System.Collections.Generic;
using System.Threading.Tasks;

public class GetListOfFinishedAndPendingMatchesUseCases
{
    private IMatchRepository _matchRepository;

    public GetListOfFinishedAndPendingMatchesUseCases(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<List<PendingMatchDTO>> GetListOfPendingMatches(int playerId)
    {
        return await _matchRepository.GetListOfPendingMatches(playerId);
    }


    public async Task<List<FinishedMatchDTO>> GetListOfFinishedMatches(int playerId)

    {
        return await _matchRepository.GetListOfFinishedMatches(playerId);
    }
}