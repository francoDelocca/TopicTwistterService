using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopicTwisterService.shared.Application;

namespace TopicTwisterService.Notification.Infraestructure
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }
      
        [HttpGet("{playerId}")]
        public async Task<ActionResult<Response>> GetNotifications(int playerId)
        {
            IsNotificationsUserCase isNotificationsUserCase =
             new IsNotificationsUserCase(notificationRepository);
            Response oResponse = new();
            try
            {
                bool isNotication = await isNotificationsUserCase.AnyNotificationForUser(playerId);
                oResponse.data =
                    oResponse.data = JsonConvert.SerializeObject(isNotication,
                        new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
                oResponse.success = 1;
            }
            catch (Exception ex)
            {
                oResponse.message = ex.ToString();
                oResponse.success = 0;
            }

            return oResponse;
        }


    }
}
