using Jmepromeneavecmesvalises_API.Data;
using Jmepromeneavecmesvalises_API.Models;

namespace Jmepromeneavecmesvalises_API.Services;

public class PhotosService
{
    private readonly Jmepromeneavecmesvalises_APIContext _context;
    public PhotosService(Jmepromeneavecmesvalises_APIContext context)
    {
        _context = context;
    }
    
    public async Task<Photo?> GetPhoto(int id)
    {
        Photo? photo = await _context.Photos.FindAsync(id);
        
        if (photo == null)
        {
            return null;
        }
        
        return photo;
    }
    
    public async Task AddPhoto(IFormFile file, Voyage voyage)
    {
        Image image = await Image.LoadAsync(file.OpenReadStream());
        Photo photo = new Photo
        {
            Filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName),
            MimeType = file.ContentType,
            Voyage = voyage
        };

        Directory.CreateDirectory("C:\\image");
        await image.SaveAsync("C:\\image\\" + photo.Filename);

        await _context.Photos.AddAsync(photo);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeletePhoto(Photo photo)
    {
        File.Delete("C:\\image\\" + photo.Filename);

        _context.Photos.Remove(photo);
        await _context.SaveChangesAsync();
    }
}