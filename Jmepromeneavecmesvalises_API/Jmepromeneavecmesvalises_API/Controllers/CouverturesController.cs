using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jmepromeneavecmesvalises_API.Data;
using Jmepromeneavecmesvalises_API.Models;
using Jmepromeneavecmesvalises_API.Services;
using Microsoft.AspNetCore.Identity;

namespace Jmepromeneavecmesvalises_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouverturesController : ControllerBase
    {
        private readonly Jmepromeneavecmesvalises_APIContext _context;
        private readonly VoyagesService _voyagesService;
        private readonly CouverturesService _couverturesService;
        private readonly UserManager<User> _userManager;
        private User? _user;

        public CouverturesController(Jmepromeneavecmesvalises_APIContext context, VoyagesService voyagesService,
            CouverturesService couverturesService, UserManager<User> userManager)
        {
            _context = context;
            _voyagesService = voyagesService;
            _couverturesService = couverturesService;
            _userManager = userManager;
        }

        // GET: api/Couvertures/5
        [HttpGet("{voyageId}")]
        public async Task<ActionResult<Couverture>> GetCouverture(int voyageId)
        {
            Voyage? voyage = await _voyagesService.GetVoyage(voyageId);

            if (voyage == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new { Message = "la voyage n'existe pas" });
            }

            Couverture photo = voyage.Couverture;

            if (photo == null)
            {
                return NotFound();
            }

            byte[] bytes = System.IO.File.ReadAllBytes("C:\\image\\couvertures\\" + photo.Filename);
            return File(bytes, photo.MimeType);
        }

        // POST: api/Couvertures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{voyageId}")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Couverture>> PostCouverture(int voyageId)
        {
            Voyage? voyage = await _voyagesService.GetVoyage(voyageId);

            if (voyage == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new { Message = "la voyage n'existe pas" });
            }

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
                _user = await _userManager.FindByIdAsync(userId);

            if (_user == null || !voyage.Proprietaires.Contains(_user))
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    new { Message = "la voyage n'apartient pas a cette utilisateur" });
            }

            if (voyage.Couverture != null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    new { Message = "la voyage a deja une couverture" });
            }

            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.GetFile("monImage");

                if (file != null)
                {
                    await _couverturesService.PostCouverture(file, voyage);
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

        // PUT: api/dasfsdf/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{voyageId}")]
        public async Task<IActionResult> PutCouverture(int voyageId)
        {
            Voyage? voyage = await _voyagesService.GetVoyage(voyageId);

            if (voyage == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new { Message = "la voyage n'existe pas" });
            }

            Couverture photo = voyage.Couverture;

            if (photo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new { Message = "la voyage n'a pas de couverture" });
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
                    await _couverturesService.PutCouverture(photo, file, voyage);
                }
                else
                {
                    return NotFound(new { Message = "Aucune image fournie" });
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_couverturesService.CouvertureExists(photo.Id))
                    return NotFound();
                throw;
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok();
        }

        // DELETE: api/Couvertures/5
        [HttpDelete("{voyageId}")]
        public async Task<IActionResult> DeleteCouverture(int voyageId)
        {
            Voyage? voyage = await _voyagesService.GetVoyage(voyageId);

            if (voyage == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new { Message = "la voyage n'existe pas" });
            }

            Couverture? photo = voyage.Couverture;
            if (photo == null)
            {
                return NotFound();
            }

            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
                _user = await _userManager.FindByIdAsync(userId);

            if (_user == null || !voyage.Proprietaires.Contains(_user))
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    new { Message = "la voyage n'apartient pas a cette utilisateur" });
            }

            await _couverturesService.DeleteCouverture(photo);
            return NoContent();
        }
    }
}