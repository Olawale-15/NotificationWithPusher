namespace NotificationWithPusher.Model
{
    public class Notification
    {
        public string Tittle { get; set; } = default!;
        public string Message { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
