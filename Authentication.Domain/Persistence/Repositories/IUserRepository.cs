using Authentication.Domain.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Persistence.Repositories
{
    public interface IUserRepository
    {
        public Task<User> CreateUserAsync(User user);
        public Task<User> UpdateUserAsync(User user);
        public Task DeleteUserAsync(int userId);
        public Task<User> GetUserByIdAsync(int userId);
        public Task<IEnumerable<User>> ListAsync();
    }
}
