﻿using System.Text.Json.Serialization;

namespace Jmepromeneavecmesvalises_API.Models;

public class Couverture
{
    public int Id { get; set; }
    public string Filename { get; set; } = "";
    public string MimeType { get; set; } = "";
    
    public int VoyageId { get; set; }
    [JsonIgnore]
    public virtual Voyage? Voyage { get; set; }
}