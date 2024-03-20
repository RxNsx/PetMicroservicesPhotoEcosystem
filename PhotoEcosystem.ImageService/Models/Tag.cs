using System;

namespace PhotoEcosystem.ImageService.Models;
public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Album Album { get; set; }
    public Photo Photo { get; set; }
}