using System;

namespace TopicTwisterService.Category.Infrastructure.DTO
{
    [Serializable]
    public class EnteredWordsDTO
    {
        public int categoryId { get; set; }
        public int PlayerId { get; set; }
        public int RoundId { get; set; }
        public string word { get; set; }
        public string letter { get; set; }
        public bool isValidWord { get; set; }
    }
}