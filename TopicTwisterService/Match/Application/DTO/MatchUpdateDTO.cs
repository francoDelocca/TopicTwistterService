using System.Collections.Generic;

namespace TopicTwisterService.Match.Application.DTO
{
    public class MatchUpdateDTO
    {
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int RoundId { get; set; }
        public int TimeByPlayer { get; set; }

        public List<int> categoriesId { get; set; }
        public List<string> enteredWords { get; set; }
        public List<bool> IsValid { get; set; }
    }
}