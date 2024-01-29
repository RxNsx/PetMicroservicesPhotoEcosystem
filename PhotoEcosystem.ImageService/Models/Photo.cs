namespace PhotoEcosystem.ImageService.Models;
public class Photo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsPrivate { get; set; }
    public bool IsFavourite { get; set; }
    public int LikesCount { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    List<Album> Albums { get; set; } = new List<Album>();
}