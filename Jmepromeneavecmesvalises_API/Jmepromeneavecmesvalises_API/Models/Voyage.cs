using System.Text.Json.Serialization;

namespace Jmepromeneavecmesvalises_API.Models;

public class Voyage
{
    public int Id { get; set; }

    public string Destination { get; set; }

    public Photo Couverture { get; set; }

    public bool IsPublic { get; set; }

    [JsonIgnore] public virtual List<User> Proprietaires { get; set; } = new List<User>();

    public virtual List<Photo> Photos { get; set; } = new List<Photo>();

    public Voyage()
    {
    }

    public Voyage(VoyageDTO voyageDTO)
    {
        Id = voyageDTO.Id;
        Destination = voyageDTO.Destination;
        Couverture = voyageDTO.Couverture;
        IsPublic = voyageDTO.IsPublic;
    }
}