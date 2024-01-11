using PhotoEcosystem.UserService.Dtos.Users;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User createUser);
        Task<User> UpdateUserAsync(User updateUser);
        Task DeleteUserAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<bool> IsUserExists(string login);
    }
}
