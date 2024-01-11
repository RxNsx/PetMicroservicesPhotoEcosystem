using Microsoft.AspNetCore.Identity;
using PhotoEcosystem.UserService.Data;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            this._context = context;
        }

        public Task CreateUser(User createUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserExists(string login)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
