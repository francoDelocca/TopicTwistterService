using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TopicTwisterService.Player.Domain;

public class PlayerRepository : EfRepository<Player>, IPlayerRepository
{
    private readonly DataContext dataContext;

    public PlayerRepository(DataContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<Player> PlayerWithEmailAndPassword(string email, string password)
    {
       return await dataContext.Players.FirstOrDefaultAsync(x => x.email == email && x.password == password);
    }

    public bool PlayerWithEmailExists(string email)
    {
        return dataContext.Players.Any(e => e.email == email);
    }
}