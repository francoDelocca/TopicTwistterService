using System;
using System.Collections.Generic;
using System.Linq;
using TopicTwisterService.Category.Infrastructure.DTO;

namespace TopicTwisterService.Round.Application
{
    public class GetValidateWordsForUserUseCase
    {
        private DataContext _context;

        public GetValidateWordsForUserUseCase(DataContext context)
        {
            _context = context;
        }

        public object GetValidatedWordsFromPlayer(int playerId, int roundId)
            {
                try
                {
                    return _context.WordsEnteredByPlayer.Where(x => x.PlayerId == playerId && x.RoundId == roundId).Select(x => new
                    EnteredWordsDTO() {
                        word = x.WordEntered,
                        isValidWord = (bool)x.IsValid,
                        PlayerId = x.PlayerId
                    }).ToList();
                }
                catch (Exception)
                {
        
                    return new List<string>();
                }
            }
        
    }
}