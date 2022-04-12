public class Match2MatchDTO
{
    public MatchDTO map(Match match)
    {
        MatchDTO matchDto = new MatchDTO();

        matchDto.MatchId = match.MatchId;
        matchDto.PlayerOne = match.PlayerOne;
        matchDto.PlayerTwo = match.PlayerTwo;
        matchDto.WinnerPlayer = match.WinnerPlayer;
        matchDto.MatchClosed = match.MatchClosed;

        foreach (var round in match.Rounds)
        {
            Round2RoundDTO round2RoundDTO = new Round2RoundDTO();
            matchDto.Rounds.Add(round2RoundDTO.map(round));
        }

        return matchDto;
    }
}