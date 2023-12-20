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
}