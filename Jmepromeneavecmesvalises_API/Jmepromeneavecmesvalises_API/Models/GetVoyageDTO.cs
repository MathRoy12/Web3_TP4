namespace Jmepromeneavecmesvalises_API.Models;

public class GetVoyageDTO
{
    public int Id { get; set; }

    public string Destination { get; set; }
    
    public List<Photo> Photos { get; set; } = new List<Photo>();
    
    public GetVoyageDTO(Voyage voyage)
    {
        Id = voyage.Id;
        Destination = voyage.Destination;
        Photos = voyage.Photos;
    }
}