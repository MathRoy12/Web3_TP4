using Microsoft.AspNetCore.Identity;

namespace Jmepromeneavecmesvalises_API.Models;

public class User : IdentityUser
{
    public virtual List<Voyage>? Voyages { get; set; }
}