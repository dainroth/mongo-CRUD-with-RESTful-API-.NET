using Microsoft.AspNetCore.Mvc;

namespace AutoCoolApi.Controllers;

[ApiController]
[Route("image")]
public class FileController : ControllerBase
{
    private readonly IWebHostEnvironment _env;
    public FileController(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpGet("preview/{fileName}")]
    public IActionResult Preview(string fileName)
    {
        var uploadPath = Path.Combine(_env.WebRootPath, "uploads");
        var filePath = Path.Combine(uploadPath, fileName);

        if (!System.IO.File.Exists(filePath))
            return NotFound("File not found.");

        var mimeType = "image/" + Path.GetExtension(filePath).TrimStart('.').ToLower();
        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        return File(fileStream, mimeType);
    }
}
