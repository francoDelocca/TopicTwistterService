using System.Threading.Tasks;

public class ContinueMatchUseCase
{
    private IMatchRepository _matchRepository;

    public ContinueMatchUseCase(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<MatchDTO> GetMatch(int id)
    {
        Match2MatchDTO adapter = new Match2MatchDTO();
        return adapter.map(await _matchRepository.GetFullMatch(id));
    }
}