using System.Threading.Tasks;
using TopicTwisterService.shared.Domain;

namespace TopicTwisterService.Player.Domain
{
    public interface IPlayerRepository : IAsyncRepository<Player>
    {
        bool PlayerWithEmailExists(string email);
        Task<Player> PlayerWithEmailAndPassword(string email, string password);
    }
}