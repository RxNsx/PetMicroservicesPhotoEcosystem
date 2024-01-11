using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Dtos.Users
{
    public class UserReadDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Status Status { get; set; }
        public DateTime LastTimeOnline { get; set; }
    }
}
