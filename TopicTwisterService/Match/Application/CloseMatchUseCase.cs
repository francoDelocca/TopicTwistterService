using System.Threading.Tasks;

public class CloseMatchUseCase
{
    private IMatchRepository _matchRepository;

    public CloseMatchUseCase(IMatchRepository matchRepository)
    {
        _matchRepository = matchRepository;
    }

    public async Task<bool> Close(int MatchId)
    {
        Match matchToClose = await _matchRepository.GetFullMatch(MatchId);

        if (matchToClose.AllRoundsWerePlayed())
        {
            matchToClose.Close();
            await _matchRepository.Update(matchToClose);
            return true;
        }
        return false;
    }
}