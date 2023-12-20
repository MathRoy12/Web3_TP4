using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jmepromeneavecmesvalises_API.Models;
using Jmepromeneavecmesvalises_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Jmepromeneavecmesvalises_API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class VoyagesController : ControllerBase
{
    private readonly VoyagesService _service;
    private readonly UserManager<User> _userManager;
    private User? _user;

    public VoyagesController(UserManager<User> userManager, VoyagesService service)
    {
        _userManager = userManager;
        _service = service;
    }

    // GET: api/Voyages
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<VoyageDTO>>> GetVoyage()
    {
        List<VoyageDTO>? data;

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
            _user = await _userManager.FindByIdAsync(userId);

        if (await _service.GetVoyage(_user) == null)
        {
            return Problem("Entity set 'Jmepromeneavecmesvalises_APIContext.Voyage'  is null.");
        }

        data = await _service.GetVoyage(_user);

        if (data == null)
            return NotFound();

        return data;
    }

    // GET: api/Voyages/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetVoyageDTO>> GetVoyage(int id)
    {
        Voyage? voyage = await _service.GetVoyage(id);

        if (voyage == null)
        {
            return NotFound();
        }

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
            _user = await _userManager.FindByIdAsync(userId);

        if (await _service.GetVoyage(_user) == null)
        {
            return Problem("Entity set 'Jmepromeneavecmesvalises_APIContext.Voyage'  is null.");
        }

        if (_user == null || !voyage.Proprietaires.Contains(_user))
        {
            return StatusCode(StatusCodes.Status401Unauthorized,
                new { Message = "la voyage n'apartient pas a cette utilisateur" });
        }

        return new GetVoyageDTO(voyage);
    }

    // PUT: api/Voyages/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVoyage(int id, PutVoyageDTO dto)
    {
        if (id != dto.Id)
            return BadRequest();

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
            _user = await _userManager.FindByIdAsync(userId);

        if (await _service.GetVoyage(_user) == null)
        {
            return Problem("Entity set 'Jmepromeneavecmesvalises_APIContext.Voyage'  is null.");
        }

        Voyage? voyage = await _service.GetVoyage(id);

        if (voyage == null)
            return BadRequest();

        if (_user == null || !voyage.Proprietaires.Contains(_user))
        {
            return StatusCode(StatusCodes.Status401Unauthorized,
                new { Message = "la voyage n'apartient pas a cette utilisateur" });
        }

        if (dto.NewUserEmail == null)
            return BadRequest();

        User? newUser = await _userManager.FindByEmailAsync(dto.NewUserEmail);

        try
        {
            await _service.PutVoyage(id, voyage, dto, newUser);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_service.VoyageExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // POST: api/Voyages
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<VoyageDTO>> PostVoyage(PostVoyageDTO dto)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
            _user = await _userManager.FindByIdAsync(userId);

        if (_user == null)
        {
            return StatusCode(StatusCodes.Status401Unauthorized,
                new { Message = "Il n'y a aucun utilisateur de connecter" });
        }

        if (await _service.GetVoyage(_user) == null)
        {
            return Problem("Entity set 'Jmepromeneavecmesvalises_APIContext.Voyage'  is null.");
        }

        Voyage voyage = await _service.PostVoyage(dto, _user);

        return new VoyageDTO(voyage, true);
    }

    // DELETE: api/Voyages/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVoyage(int id)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
            _user = await _userManager.FindByIdAsync(userId);

        if (_user == null)
        {
            return StatusCode(StatusCodes.Status401Unauthorized,
                new { Message = "Il n'y a aucun utilisateur de connecter" });
        }

        if (await _service.GetVoyage(_user) == null)
        {
            return Problem("Entity set 'Jmepromeneavecmesvalises_APIContext.Voyage'  is null.");
        }

        Voyage? voyage = await _service.GetVoyage(id);
        if (voyage == null)
        {
            return NotFound();
        }

        if (!voyage.Proprietaires.Contains(_user))
        {
            return StatusCode(StatusCodes.Status401Unauthorized,
                new { Message = "Le voyage n'apartient pas a cet utilisateur" });
        }

        await _service.DeleteVoyage(id);

        return NoContent();
    }
}