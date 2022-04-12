using System.Threading.Tasks;
using TopicTwisterService.Player.Domain;

public class FindOrCreateNewMatchUseCase
{
    private IMatchRepository _matchRepository;
    private IPlayerRepository _playerRepository;
    private IRoundRepository _roundRepository;

    public FindOrCreateNewMatchUseCase(IMatchRepository matchRepository, IPlayerRepository playerRepository,
        IRoundRepository roundRepository)
    {
        _matchRepository = matchRepository;
        _playerRepository = playerRepository;
        _roundRepository = roundRepository;
    }

    public async Task<Match> FindOrCreateNewMatch(int playerId)
    {
        Player player = await _playerRepository.GetById(playerId);
        Match match = FindBrandNewPlayableMatch(playerId);

        if (match != null)
        {
            //It exists a match
            match.PlayerTwo = player;
            await _matchRepository.Update(match);
        }
        else //We create a new match
        {
            CreateRoundToPlayUseCase createRoundToPlayUseCase = new CreateRoundToPlayUseCase(_roundRepository);
            //creo round 
            Round round = createRoundToPlayUseCase.CreateRoundToPlay();
            match = new Match(player, round);
            await _matchRepository.Add(match);
        }

        return match;
    }

    public Match FindBrandNewPlayableMatch(int playerId)
    {
        return _matchRepository.FindBrandNewPlayableMatch(playerId);
    }
}