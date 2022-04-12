using System.Linq;

public class Match2MatchResultsDTO
{
    public MatchResultsDTO map(Match match)
    {
        MatchResultsDTO matchResultsDto = new MatchResultsDTO();

        matchResultsDto.Winner = match.WinnerPlayer;

        matchResultsDto.Loser = match.WinnerPlayer.PlayerId == match.PlayerOne.PlayerId ? match.PlayerTwo : match.PlayerOne;
        matchResultsDto.RoundsWonByWinner = match.Rounds.Count(x => x.Winner.PlayerId == match.WinnerPlayer.PlayerId);
        matchResultsDto.RoundsWonByLoser = match.Rounds.Count(x => x.Winner.PlayerId != match.WinnerPlayer.PlayerId);

        

        return matchResultsDto;
    }
}