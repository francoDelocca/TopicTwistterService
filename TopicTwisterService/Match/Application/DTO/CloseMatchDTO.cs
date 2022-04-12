using TopicTwisterService.Player.Domain;

public class CloseMatchDTO
{
    public int MatchId { get; set; }
    public Player Winner { get; set; }
    public bool Closed { get; set; }
}