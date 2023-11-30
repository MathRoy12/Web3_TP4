namespace Jmepromeneavecmesvalises_API.Models;

public class Photo
{
    public int Id { get; set; }
    public string Filename { get; set; } = "";
    public string MimeType { get; set; } = "";
    
    public int VoyageId { get; set; }
    public virtual Voyage Voyage { get; set; }
}