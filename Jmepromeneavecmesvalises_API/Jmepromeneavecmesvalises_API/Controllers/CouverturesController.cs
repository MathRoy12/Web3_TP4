using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jmepromeneavecmesvalises_API.Data;
using Jmepromeneavecmesvalises_API.Models;

namespace Jmepromeneavecmesvalises_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouverturesController : ControllerBase
    {
        private readonly Jmepromeneavecmesvalises_APIContext _context;
        private User? user;

        public CouverturesController(Jmepromeneavecmesvalises_APIContext context)
        {
            _context = context;
        }

        // GET: api/Couvertures/5
        [HttpGet("{voyageId}")]
        public async Task<ActionResult<Couverture>> GetCouverture(int voyageId)
        {
            if (_context.Photos == null)
            {
                return NotFound();
            }

            Voyage voyage = await _context.Voyage.FindAsync(voyageId);

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
            Voyage? voyage = await _context.Voyage.FindAsync(voyageId);

            if (voyage == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new { Message = "la voyage n'existe pas" });
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user = await _context.Users.FindAsync(userId);

            if (!voyage.Proprietaires.Contains(user))
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
                    Image image = Image.Load(file.OpenReadStream());
                    Couverture photo = new Couverture();

                    photo.Filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    photo.MimeType = file.ContentType;
                    photo.Voyage = await _context.Voyage.FindAsync(voyageId);

                    Directory.CreateDirectory("C:\\image\\couvertures");
                    await image.SaveAsync("C:\\image\\couvertures\\" + photo.Filename);

                    await _context.Couvertures.AddAsync(photo);
                    await _context.SaveChangesAsync();
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
            Voyage voyage = await _context.Voyage.FindAsync(voyageId);

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

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user = await _context.Users.FindAsync(userId);

            if (!voyage.Proprietaires.Contains(user))
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
                    Image image = Image.Load(file.OpenReadStream());

                    photo.MimeType = file.ContentType;

                    Directory.CreateDirectory("C:\\image\\couvertures");
                    System.IO.File.Delete("C:\\image\\couvertures\\" + photo.Filename);
                    await image.SaveAsync("C:\\image\\couvertures\\" + photo.Filename);

                    _context.Couvertures.Update(photo);

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CouvertureExists(photo.Id))
                            return NotFound();
                        throw;
                    }
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

        // DELETE: api/Couvertures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCouverture(int id)
        {
            if (_context.Photos == null)
            {
                return NotFound();
            }
            
            Voyage voyage = await _context.Voyage.FindAsync(id);
            Couverture photo = voyage.Couverture;
            if (photo == null)
            {
                return NotFound();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            user = await _context.Users.FindAsync(userId);

            if (!photo.Voyage.Proprietaires.Contains(user))
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    new { Message = "la voyage n'apartient pas a cette utilisateur" });
            }

            System.IO.File.Delete("C:\\image\\couvertures\\" + photo.Filename);

            _context.Couvertures.Remove(photo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CouvertureExists(int id)
        {
            return (_context.Couvertures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}