using System.Threading.Tasks;

public class IsNotificationsUserCase
{
    private INotificationRepository _repository;

    public IsNotificationsUserCase(INotificationRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AnyNotificationForUser(int playerId)
    {
        var notification = await _repository.GetNotificationByUserId(playerId);
        if(notification != null) await _repository.Remove(notification);
        return notification != null;
    }
}

