namespace PhotoEcosystem.UserService.Dtos.Users
{
    public class UserCreateDto
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
