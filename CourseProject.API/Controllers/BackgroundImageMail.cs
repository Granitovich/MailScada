using CourseProject.BLL.Interfaces;
using CourseProject.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CourseProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BackgroundImageMail : ControllerBase
    {
        private readonly BackgroundServicesMail _service;

        public BackgroundImageMail(BackgroundServicesMail service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBackGroundImage(int id)
        {
            var image = await _service.GetBackgroundImageAsync(id);

            return File(image.Bytes, "image/jpeg");
        }

        [HttpPost("upload-image")]
        public async Task<ActionResult> UploadImageAsync(IFormFile image)
        {
            var memoryStream = new MemoryStream();
            image.CopyTo(memoryStream);
            await _service.UploadImageAsync(memoryStream);

            return NoContent();
        }
    }
}
