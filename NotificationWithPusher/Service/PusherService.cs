using NotificationWithPusher.Model;
using PusherServer;

namespace NotificationWithPusher.Service
{
    public class PusherService
    {
        private readonly Pusher _pusher;
        public PusherService(IConfiguration config)
        {
            var options = new PusherOptions
            {
                Cluster = config["Pusher:Cluster"],
                Encrypted = true
            };
            _pusher = new Pusher(
              appId: config["Pusher:App_Id"],
              appKey: config["Pusher:Key"],
              appSecret: config["Pusher:Secret"],
              options
            );
        }

        //To view the message https://dashboard.pusher.com/apps/2012706/console
        public async Task SendNotification(Notification notification)
        {
            await _pusher.TriggerAsync("notifications", "new-notification", new
            {
                title = notification.Tittle,
                message = notification.Message,
                createdAt = notification.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
            });
        }
    }
}
