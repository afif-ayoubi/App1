using App1.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace App1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageUploadRequestDto)
        {
            return Ok();

        }
        private void ValidateFileUpload(ImageUploadRequestDto imageUploadRequestDto)
        {
            
        }
    }
}