using PhotoEcosystem.UserService.Dtos.Users;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(User createUser);
        Task UpdateUser(User updateUser);
        Task DeleteUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<bool> IsUserExists(string login);
    }
}
