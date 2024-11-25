using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using CourseProject.API.Controllers;

namespace CourseProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailTimeControl : ControllerBase
    {
        private readonly IHubContext<MailHub> _hubContext;

        public MailTimeControl(IHubContext<MailHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("start-time-updates")]
        public IActionResult StartTimeUpdates()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    var currentTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                    await _hubContext.Clients.All.SendAsync("receiveTime", currentTime);
                    await Task.Delay(1000);
                }
            });

            return Ok("Time updates started");
        }
    }

}

