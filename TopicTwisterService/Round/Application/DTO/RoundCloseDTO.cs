using System.Collections.Generic;

namespace TopicTwisterService.Round.Application.DTO
{
    public class RoundCloseDTO
    {
        public RoundCloseDTO()
        {
            Categories = new();
            WordsEnterdByPlayerUser = new();
            WordsEnterdByPlayerOpponent = new();
        }

        public int IdRound { get; set; }
        public int IdMatch { get; set; }
        public string PlayerUserName { get; set; }
        public string PlayerOpponentName { get; set; }
        public List<string> Categories { get; set; }
        public List<string> WordsEnterdByPlayerUser { get; set; }
        public List<string> WordsEnterdByPlayerOpponent { get; set; }
    }
}