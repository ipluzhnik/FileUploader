using FileUploader.Controllers.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace FileUploader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private UploadHandler helper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadController(IWebHostEnvironment webHostEnvironment) { 
            helper = new UploadHandler();
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public IActionResult UploadFiles(IFormFileCollection files)
        {
            var formFiles = files;
            var result = new UploadHandler().Upload(formFiles);
            if (result == string.Empty)
                return Ok();
            else
                return BadRequest(result);
        }
        
    }
}
