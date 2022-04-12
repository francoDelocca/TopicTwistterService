using TopicTwisterService.Player.Domain;

public class MatchResultsDTO
{
    public Player Winner { get; set; }
    public Player Loser { get; set; }
    public int RoundsWonByWinner { get; set; }
    public int RoundsWonByLoser { get; set; }
}