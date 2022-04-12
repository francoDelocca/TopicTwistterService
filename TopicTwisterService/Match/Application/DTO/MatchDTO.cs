using System.Collections.Generic;
using TopicTwisterService.Player.Domain;

public class MatchDTO
{
    public int MatchId { get; set; }
    public bool MatchClosed { get; set; }

    public Player WinnerPlayer { get; set; }
    public Player PlayerOne { get; set; }
    public Player PlayerTwo { get; set; }

    public List<RoundDTO> Rounds { get; set; } = new List<RoundDTO>();
}