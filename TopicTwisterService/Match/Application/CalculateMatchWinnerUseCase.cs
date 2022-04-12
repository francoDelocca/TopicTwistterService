using System.Linq;
using System.Threading.Tasks;

public class CalculateMatchWinnerUseCase
{
    private IMatchRepository _repository;

    public CalculateMatchWinnerUseCase(IMatchRepository repository)
    {
        _repository = repository;
    }

    public async Task<MatchResultsDTO> CalculateMatchWinner(int matchId)
    {
        MatchResultsDTO matchResultsDto = new MatchResultsDTO();
        Match match = await _repository.GetFullMatch(matchId);

        if (match is not null)
        {
            match.CalculateMatchWinner();
            match.AddWinToWinner();

            Match2MatchResultsDTO match2MatchResultsDTO = new();

            await _repository.Update(match);

            return match2MatchResultsDTO.map(match);
        }

        return matchResultsDto;
    }
}