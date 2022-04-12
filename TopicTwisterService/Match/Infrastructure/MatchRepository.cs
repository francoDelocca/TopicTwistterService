using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class MatchRepository : EfRepository<Match>, IMatchRepository
{
    private readonly DataContext _dataContext;

    public MatchRepository(DataContext dataContext) : base(dataContext)
    {
        this._dataContext = dataContext;
    }

    public Match FindBrandNewPlayableMatch(int playerId)
    {
        return _dataContext.Matches
            .Include("PlayerOne")
            .Include("PlayerTwo")
            .Include(r => r.Rounds).ThenInclude(a => a.Categories)
            .FirstOrDefault(m => m.PlayerOne.PlayerId != playerId && m.PlayerTwo == null);
    }

    public Task<List<PendingMatchDTO>> GetListOfPendingMatches(int playerId)
    {
        return _dataContext.Matches
            .Include(x => x.Rounds).ThenInclude(x => x.Winner)
            .Include(x => x.PlayerOne)
            .Include(x => x.PlayerTwo)
            .Where(x => (x.PlayerOne.PlayerId == playerId || x.PlayerTwo.PlayerId == playerId) && !x.MatchClosed)
            .Select(x => new PendingMatchDTO

            {
                MatchId = x.MatchId,
                Opponent = x.PlayerOne.PlayerId == playerId
                    ? x.PlayerTwo ?? new TopicTwisterService.Player.Domain.Player() {Name = "Oponente Digno"}
                    : x.PlayerOne,
                NumberOfRoundsWonByPlayer = x.Rounds.Where(r => r.Close && r.Winner.PlayerId == playerId).Count(),
                NumberOfRoundsWonByOpponent = x.Rounds.Where(r => r.Close && r.Winner.PlayerId != playerId).Count(),
                NumberOfRounds = x.Rounds.Count(),
                Playable = ((x.PlayerOne.PlayerId == playerId &&
                             x.Rounds.Where(r => !r.Close).Count() == 0) ||
                            ((x.PlayerTwo.PlayerId == playerId &&
                              x.Rounds.Where(r => !r.Close).Count() > 0)))
            }).ToListAsync();
    }

    public Task<List<FinishedMatchDTO>> GetListOfFinishedMatches(int playerId)
    {
        return _dataContext.Matches
            .Include(x => x.Rounds).ThenInclude(x => x.Winner)
            .Where(x => (x.PlayerOne.PlayerId == playerId || x.PlayerTwo.PlayerId == playerId) && x.MatchClosed)
            .Select(x => new FinishedMatchDTO
            {
                MatchId = x.MatchId,
                Opponent = x.PlayerOne.PlayerId == playerId
                    ? x.PlayerTwo
                    : x.PlayerOne,
                NumberOfRoundsWonByPlayer = x.Rounds.Where(r => r.Close && r.Winner.PlayerId == playerId).Count(),
                NumberOfRoundsWonByOpponent = x.Rounds.Where(r => r.Close && r.Winner.PlayerId != playerId).Count(),
                Win = (x.WinnerPlayer.PlayerId == playerId),
                NumberOfRounds = x.Rounds.Count()
            }).ToListAsync();
    }

    public async Task<Match> GetFullMatch(int matchID)
    {
        return await _dataContext.Matches
            .Include(x => x.Rounds).ThenInclude(x => x.WordEnteredByPlayers)
            .Include(x => x.Rounds).ThenInclude(x => x.Categories)
            .Include(x => x.Rounds).ThenInclude(x => x.Winner)
            .Include(x => x.PlayerOne)
            .Include(x => x.PlayerTwo)
            .Include(x => x.WinnerPlayer)
            .FirstOrDefaultAsync(x => x.MatchId == matchID);
    }
}