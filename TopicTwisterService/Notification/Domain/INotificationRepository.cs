using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopicTwisterService.shared.Domain;



public interface INotificationRepository : IAsyncRepository<Notification>
{        
    public Task<Notification> GetNotificationByUserId(int playerId);        
}

