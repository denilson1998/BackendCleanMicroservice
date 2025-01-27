using Ardalis.Specification.EntityFrameworkCore;
using Authentication.Domain.Persistence.Repositories;
using Authentication.Domain.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public Task DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _dbContext.Users
                            .Where(u => u.Id == userId)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _dbContext.Users.ToListAsync();
            
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
