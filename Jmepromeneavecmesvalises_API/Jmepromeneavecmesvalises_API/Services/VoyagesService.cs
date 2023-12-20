using Jmepromeneavecmesvalises_API.Data;
using Jmepromeneavecmesvalises_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Jmepromeneavecmesvalises_API.Services;

public class VoyagesService
{
    private readonly Jmepromeneavecmesvalises_APIContext _context;

    public VoyagesService(Jmepromeneavecmesvalises_APIContext context)
    {
        _context = context;
    }

    public async Task<List<VoyageDTO>?> GetVoyage(User? user)
    {
        if (_context.Voyage == null)
        {
            return null;
        }

        List<VoyageDTO> data = new List<VoyageDTO>();

        if (user != null)
        {
            data.InsertRange(0,
                await _context.Voyage
                    .Where(v => v.Proprietaires.Contains(user) || v.IsPublic)
                    .Select(v => new VoyageDTO(v, v.Proprietaires.Contains(user)))
                    .ToListAsync()
            );
        }
        else
        {
            data.InsertRange(0, await _context.Voyage
                .Where(v => v.IsPublic)
                .Select(v => new VoyageDTO(v, false))
                .ToListAsync());
        }

        return data;
    }

    public async Task<Voyage?> GetVoyage(int id)
    {
        return await _context.Voyage.FindAsync(id);
    }

    public async Task PutVoyage(int id, Voyage voyage, PutVoyageDTO dto, User? newUser)
    {
        if (newUser != null)
            voyage.Proprietaires.Add(newUser);

        voyage.Destination = dto.Destination;
        voyage.Couverture = dto.Couverture;
        voyage.IsPublic = dto.IsPublic;

        _context.Entry(voyage).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Voyage> PostVoyage(PostVoyageDTO dto, User owner)
    {
        Voyage voyage = new Voyage(dto);
        if (dto.IsOwner)
            voyage.Proprietaires.Add(owner);

        _context.Voyage.Add(voyage);
        await _context.SaveChangesAsync();

        return voyage;
    }

    public async Task DeleteVoyage(int id)
    {
        Voyage? voyage = await _context.Voyage.FindAsync(id);
        if (voyage == null)
        {
            return;
        }
        _context.Voyage.Remove(voyage);
        await _context.SaveChangesAsync();
    }

    public bool VoyageExists(int id)
    {
        return _context.Voyage.Any(e => e.Id == id);
    }
}