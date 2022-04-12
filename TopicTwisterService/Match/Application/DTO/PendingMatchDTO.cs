using TopicTwisterService.Player.Domain;

public class PendingMatchDTO
{
    public int MatchId { get; set; }
    public Player Opponent { get; set; }
    public int NumberOfRoundsWonByPlayer { get; set; }
    public int NumberOfRoundsWonByOpponent { get; set; }
    public int NumberOfRounds { get; set; }    
    public bool Playable { get; set; }
}

public class FinishedMatchDTO
{
    public int MatchId { get; set; }
    public Player Opponent { get; set; }
    public int NumberOfRoundsWonByPlayer { get; set; }
    public int NumberOfRoundsWonByOpponent { get; set; }
    public int NumberOfRounds { get; set; }
    public bool Win { get; set; }    
}