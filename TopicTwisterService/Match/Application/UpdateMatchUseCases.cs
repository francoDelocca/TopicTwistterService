using System;
using System.Threading.Tasks;
using TopicTwisterService.Match.Application.DTO;

public class UpdateMatchUseCases
{
    private readonly IMatchRepository _matchRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IWordsEnteredByPlayerRepository _wordsEnteredByPlayerRepository;

    public UpdateMatchUseCases(IMatchRepository matchRepository, ICategoryRepository categoryRepository,
        IWordsEnteredByPlayerRepository wordsEnteredByPlayerRepository)
    {
        _matchRepository = matchRepository;
        _categoryRepository = categoryRepository;
        _wordsEnteredByPlayerRepository = wordsEnteredByPlayerRepository;
    }

    public async Task UpdateMatch(MatchUpdateDTO matchDTO)
    {
        try
        {
            Match match = await this._matchRepository.GetFullMatch(matchDTO.MatchId);

            if (match.PlayerOne.PlayerId == matchDTO.PlayerId)
            {
                match.Rounds.Find(x => x.RoundId == matchDTO.RoundId).TimeByPlayerOne = matchDTO.TimeByPlayer;
            }
            else
            {
                match.Rounds.Find(x => x.RoundId == matchDTO.RoundId).TimeByPlayerTwo = matchDTO.TimeByPlayer;
            }

            await AddWordsEnteredByPlayer(matchDTO, match);

            await _matchRepository.Update(match);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private async Task AddWordsEnteredByPlayer(MatchUpdateDTO matchDTO, Match match)
    {
        for (int i = 0; i < matchDTO.categoriesId.Count; i++)
        {
            var categoryId = matchDTO.categoriesId[i];
            var wordEntered = matchDTO.enteredWords[i];
            var word = new WordsEnteredByPlayer(matchDTO.PlayerId, matchDTO.RoundId, categoryId, wordEntered,
                new WordsValidation(_categoryRepository)
                    .IsValidWord(categoryId, wordEntered, match.getCurrentRound().RoundLetter.ToString()));

            await _wordsEnteredByPlayerRepository.Add(word);
        }
    }

    public async Task DeleteMatch(int matchId)
    {
        var match = await _matchRepository.GetById(matchId);
        await _matchRepository.Remove(match);
    }
}