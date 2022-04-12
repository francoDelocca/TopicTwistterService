using TopicTwisterService.Player.Domain;

public class WordsEnteredByPlayer
{
    public WordsEnteredByPlayer(int playerId, int roundId, int categoryId, string wordEntered, bool isValid)
    {
        PlayerId = playerId;
        RoundId = roundId;
        CategoryId = categoryId;
        WordEntered = wordEntered;
        IsValid = isValid;
    }

    public WordsEnteredByPlayer()
    {
    }

    public int WordsEnteredByPlayerId { get; set; }
    public int PlayerId { get; set; }
    public Player Player { get; set; }
    public int RoundId { get; set; }
    public Round Round { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string WordEntered { get; set; }
    public bool? IsValid { get; set; }
}