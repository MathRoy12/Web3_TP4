namespace Jmepromeneavecmesvalises_API.Models;

public class PostVoyageDTO
{ 
    public int Id { get; set; }

    public string Destination { get; set; }

    public bool IsPublic { get; set; }
    public bool IsOwner { get; set; }

    public PostVoyageDTO()
    {
    }
    
    public PostVoyageDTO(Voyage voyage, bool isOwner)
    {
        Id = voyage.Id;
        Destination = voyage.Destination;
        IsPublic = voyage.IsPublic;
        IsOwner = isOwner;
    }
}