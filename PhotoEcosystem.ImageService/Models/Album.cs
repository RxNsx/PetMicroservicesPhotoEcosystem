namespace PhotoEcosystem.ImageService.Models;
public class Album
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsPrivate { get; set; }
    public bool IsFavourite { get; set; }
    public int LikesCount { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public List<Photo> Photos { get; set; } = new List<Photo>();
}