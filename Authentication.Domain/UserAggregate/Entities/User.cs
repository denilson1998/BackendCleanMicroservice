using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.UserAggregate.Entities
{
    public class User(string name, string email, string password, string emailConfirmed) : EntityBase, IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
        public string Email { get; private set; } = Guard.Against.NullOrEmpty(email, nameof(email));
        public string Password { get; private set; } = Guard.Against.NullOrEmpty(password, nameof(password));
        public string EmailConfirmed { get; private set; } = Guard.Against.NullOrEmpty(emailConfirmed, nameof(emailConfirmed));
        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;

        public void UpdateUser(string newName, string newEmail, string newPassword)
        {
            Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
            Email = Guard.Against.NullOrEmpty(newEmail, nameof(newEmail));
            Password = Guard.Against.NullOrEmpty(newPassword, nameof(newPassword));
        }

    }
}
