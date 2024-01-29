namespace PhotoEcosystem.ImageService.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime LastTimeOnline { get; set; }
    public List<Album> Albums { get; set; } = new List<Album>();
    public List<Photo> Photos { get; set; } = new List<Photo>();
}