using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class NotificationRepository : EfRepository<Notification>, INotificationRepository
{
    private readonly DataContext context;

    public NotificationRepository(DataContext context) : base(context)
    {
        this.context = context;
    }

    public Task<Notification> GetNotificationByUserId(int playerId)
    {
        var notification = context.Notifications.Where(a => a.PlayerId == playerId).SingleOrDefaultAsync();
        return notification;
    }
}

