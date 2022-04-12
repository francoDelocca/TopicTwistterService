using System;
using System.Threading.Tasks;
using TopicTwisterService.Player.Domain;

public class CreateUserUseCase
{
    private readonly IPlayerRepository playerRepository;

    public CreateUserUseCase(IPlayerRepository playerRepository)
    {
        this.playerRepository = playerRepository;
    }

    public async Task CreateUser(Player player)
    {
        await playerRepository.Add(player);
    }
}