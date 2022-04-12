using TopicTwisterService.Player.Domain;

public class Notification
{
    public int NotificationId { get; set; }
    public int PlayerId { get; set; }
    public Player Player { get; set; }
}

