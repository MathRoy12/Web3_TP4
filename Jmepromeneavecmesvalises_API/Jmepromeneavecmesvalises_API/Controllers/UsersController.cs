using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Jmepromeneavecmesvalises_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Jmepromeneavecmesvalises_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO dto)
        {
            if (dto.Password != dto.ConfirmPassword)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Les mots de passe ne correspondent pas." });
            }

            User user = new User()
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "L'utilisateur n'a pas pu être créé." });
            }
            
            LoginDTO loginDTO = new LoginDTO()
            {
                Email = dto.Email,
                Password = dto.Password
            };
            
            return await Login(loginDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO dto)
        {
            User? user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                List<Claim> authClaims = new List<Claim>();
                foreach (string role in roles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                SymmetricSecurityKey key =
                    new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes("Loo00ongue Phrase SiNoN Ca ne Marchera PaAaAAAaAas"));
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "https://localhost:7023",
                    audience: "https://localhost:4200",
                    expires: DateTime.Now.AddHours(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Le nom d'utilisateur ou le mot de passe est invaldie." });
            }
        }
    }
}