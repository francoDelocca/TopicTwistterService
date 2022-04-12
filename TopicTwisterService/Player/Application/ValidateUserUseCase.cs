using System.Threading.Tasks;
using TopicTwisterService.Player.Domain;

public class ValidateUserUseCase
{
    private readonly IPlayerRepository playerRepository;

    public ValidateUserUseCase(IPlayerRepository playerRepository)
    {
        this.playerRepository = playerRepository;
    }

    public async Task<Player> ValidateUser(string email, string password)
    {
        return await playerRepository.PlayerWithEmailAndPassword(email,password);
    }
}
