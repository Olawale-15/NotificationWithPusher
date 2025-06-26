using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationWithPusher.Model;
using NotificationWithPusher.Service;

namespace NotificationWithPusher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly PusherService _pusherService;

        public NotificationController(PusherService pusherService)
        {
            _pusherService = pusherService;
        }

        [HttpPost("send-notification")]
        public async Task<IActionResult> SendNotificationAsync([FromBody] Notification notification)
        {
            if (string.IsNullOrWhiteSpace(notification.Tittle) || string.IsNullOrWhiteSpace(notification.Message))
            {
                return BadRequest(new { error = "Title and Message are required." });
            }

            await _pusherService.SendNotification(notification);
            return Ok(new { status = "Notification sent!", notification });
        }  
    }
}
