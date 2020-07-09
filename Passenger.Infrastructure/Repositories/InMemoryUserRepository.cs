using System;
using System.Collections.Generic;
using System.Linq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("user1@test.pl", "user1", "user", "salt", "salt"),
            new User("user2@test.pl", "user2", "user", "salt", "salt"),
            new User("user3@test.pl", "user3", "user", "salt", "salt")
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id) => _users.SingleOrDefault(x => x.Id == id);

        public User Get(string email) => _users.SingleOrDefault(x => x.Email == email.ToLowerInvariant());

        public IEnumerable<User> GetAll() => _users;

        public void Remove(Guid id)
        {
           var user = Get(id);
           _users.Remove(user);
        }

        public void Update(User user)
        {
        }
    }
}

