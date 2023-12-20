using Jmepromeneavecmesvalises_API.Data;
using Jmepromeneavecmesvalises_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Jmepromeneavecmesvalises_API.Services;

public class CouverturesService
{
    private readonly Jmepromeneavecmesvalises_APIContext _context;

    public CouverturesService(Jmepromeneavecmesvalises_APIContext context)
    {
        _context = context;
    }

    public async Task PostCouverture(IFormFile file, Voyage voyage)
    {
        Image image = await Image.LoadAsync(file.OpenReadStream());
        Couverture photo = new Couverture
        {
            Filename = Guid.NewGuid() + Path.GetExtension(file.FileName),
            MimeType = file.ContentType,
            Voyage = voyage
        };

        Directory.CreateDirectory("C:\\image\\couvertures\\");
        await image.SaveAsync("C:\\image\\couvertures\\" + photo.Filename);

        await _context.Couvertures.AddAsync(photo);
        await _context.SaveChangesAsync();
    }

    public async Task PutCouverture(Couverture photo, IFormFile file, Voyage voyage)
    {
        Image image = await Image.LoadAsync(file.OpenReadStream());

        photo.MimeType = file.ContentType;

        Directory.CreateDirectory("C:\\image\\couvertures");
        File.Delete("C:\\image\\couvertures\\" + photo.Filename);
        await image.SaveAsync("C:\\image\\couvertures\\" + photo.Filename);

        _context.Couvertures.Update(photo);

        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteCouverture(Couverture photo)
    {
        File.Delete("C:\\image\\couvertures\\" + photo.Filename);

        _context.Couvertures.Remove(photo);
        await _context.SaveChangesAsync();
    }

    public bool CouvertureExists(int id)
    {
        return (_context.Couvertures?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}