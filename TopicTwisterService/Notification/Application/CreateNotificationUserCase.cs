using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CreateNotificationUserCase
{
    private INotificationRepository _repository;
    private readonly IMatchRepository _matchRepository;

    public CreateNotificationUserCase(INotificationRepository repository, IMatchRepository matchRepository)
    {
        _repository = repository;
        _matchRepository = matchRepository;
    }

    public async Task CreateNotificatioIfDontExists(int IdMatch)
    {
        var match = await _matchRepository.GetFullMatch(IdMatch);
        var notificationPlayerOne = await _repository.GetNotificationByUserId(match.PlayerOne.PlayerId);
        Notification notificationPlayerTwo = null;
        if (match.PlayerTwo !=null) 
            notificationPlayerTwo = await _repository.GetNotificationByUserId(match.PlayerTwo.PlayerId);

        if (notificationPlayerOne == null)
        {
            var NotificationForUser = new Notification() { PlayerId = match.PlayerOne.PlayerId };
            await _repository.Add(NotificationForUser);       
        }

        if (match.PlayerTwo != null && notificationPlayerTwo == null)
        {
            var NotificationForUser = new Notification() { PlayerId = match.PlayerTwo.PlayerId };
            await _repository.Add(NotificationForUser);
        }
    }


}
