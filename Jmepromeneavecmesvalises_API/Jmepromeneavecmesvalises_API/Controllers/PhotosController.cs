using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Jmepromeneavecmesvalises_API.Models;
using Jmepromeneavecmesvalises_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Jmepromeneavecmesvalises_API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PhotosController : ControllerBase
{
    private readonly PhotosService _photosService;
    private readonly VoyagesService _voyagesService;
    private readonly UserManager<User> _userManager;
    private User? _user;

    public PhotosController(PhotosService service, VoyagesService voyagesService, UserManager<User> userManager)
    {
        _photosService = service;
        _voyagesService = voyagesService;
        _userManager = userManager;
    }

    // GET: api/Photos/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult> GetPhoto(int id)
    {
        Photo? photo = await _photosService.GetPhoto(id);

        if (photo == null)
        {
            return NotFound();
        }

        byte[] bytes = System.IO.File.ReadAllBytes("C:\\image\\" + photo.Filename);
        return File(bytes, photo.MimeType);
    }

    // POST: api/Photos
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("{voyageId}")]
    [DisableRequestSizeLimit]
    public async Task<ActionResult<Photo>> PostPhoto(int voyageId)
    {
        Voyage? voyage = await _voyagesService.GetVoyage(voyageId);

        if (voyage == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest,
                new { Message = "Aucun voyage avec cet id" });
        }

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
            _user = await _userManager.FindByIdAsync(userId);

        if (_user == null || !voyage.Proprietaires.Contains(_user))
        {
            return StatusCode(StatusCodes.Status401Unauthorized,
                new { Message = "la voyage n'apartient pas a cette utilisateur" });
        }

        try
        {
            IFormCollection formCollection = await Request.ReadFormAsync();
            IFormFile? file = formCollection.Files.GetFile("monImage");

            if (file != null)
            {
                await _photosService.AddPhoto(file, voyage);
            }
            else
            {
                return NotFound(new { Message = "Aucune image fournie" });
            }
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }

        return Ok();
    }

    // DELETE: api/Photos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhoto(int id)
    {
        Photo? photo = await _photosService.GetPhoto(id);
        if (photo == null)
        {
            return NotFound();
        }

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
            _user = await _userManager.FindByIdAsync(userId);

        if (_user == null || !photo.Voyage.Proprietaires.Contains(_user))
        {
            return StatusCode(StatusCodes.Status401Unauthorized,
                new { Message = "la voyage n'apartient pas a cette utilisateur" });
        }

        await _photosService.DeletePhoto(photo);

        return NoContent();
    }
}