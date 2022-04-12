using System.Threading.Tasks;

public class CloseRoundUseCase
{
    private readonly DataContext _context;

    public CloseRoundUseCase(DataContext context)
    {
        _context = context;
    }

    public async Task CloseRound(int roundId)
    {
        Round round = await _context.Rounds.FindAsync(roundId);
        round.CloseRound();
        await _context.SaveChangesAsync();
    }
}