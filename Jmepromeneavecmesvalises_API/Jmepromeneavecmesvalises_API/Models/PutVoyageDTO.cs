﻿namespace Jmepromeneavecmesvalises_API.Models;

public class PutVoyageDTO
{
    public int Id { get; set; }

    public string Destination { get; set; }

    public string Img { get; set; }

    public bool IsPublic { get; set; }
    
    public String? NewUserEmail { get; set; }
}