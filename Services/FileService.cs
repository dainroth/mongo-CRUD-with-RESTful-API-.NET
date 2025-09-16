namespace FinalApi.Services;

public class FileService
{

    private readonly IWebHostEnvironment _env;
    public FileService(IWebHostEnvironment env)
    {
        _env = env;
    }
    public async Task<string> Upload(IFormFile file)
    {

        // Create uploads folder automatically if missing
        var uploadPath = Path.Combine(_env.WebRootPath, "uploads");
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        // Generate unique filename
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadPath, fileName);

        // Save file
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Save info to DB
        // var relativePath = $"/uploads/{fileName}";
        return fileName;
    }
}
