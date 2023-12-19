using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Jmepromeneavecmesvalises_API.Data;
using Jmepromeneavecmesvalises_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Jmepromeneavecmesvalises_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PhotosController : ControllerBase
    {
        private readonly Jmepromeneavecmesvalises_APIContext _context;
        private User? user;

        public PhotosController(Jmepromeneavecmesvalises_APIContext context)
        {
            _context = context;
        }

        // GET: api/Photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPhoto(int id)
        {
            if (_context.Photos == null)
            {
                return NotFound();
            }

            Photo? photo = await _context.Photos.FindAsync(id);
            
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
            Voyage? voyage = await _context.Voyage.FindAsync(voyageId);
            
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
                    Photo photo = new Photo();

                    photo.Filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    photo.MimeType = file.ContentType;
                    photo.Voyage = voyage;

                    Directory.CreateDirectory("C:\\image");
                    await image.SaveAsync("C:\\image\\" + photo.Filename);

                    await _context.Photos.AddAsync(photo);
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

        // DELETE: api/Photos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            if (_context.Photos == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos.FindAsync(id);
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

            System.IO.File.Delete("C:\\image\\" + photo.Filename);
            
            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}