using System.Collections.Generic;
using EventAPI.Models;

namespace EventAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();
        private int _nextId = 1;

        public User CreateUser(User userDetails)
        {
            userDetails.Id = _nextId++;
            _users.Add(userDetails);
            return userDetails;
        }

        public User GetUser(int id)
        {
            return _users.Find(user => user.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public User UpdateUser(int id, User userDetails)
        {
            var existingUser = _users.Find(user => user.Id == id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Username = userDetails.Username;
            existingUser.Password = userDetails.Password;

            return existingUser;
        }

        public bool DeleteUser(int id)
        {
            var user = _users.Find(user => user.Id == id);
            if (user == null)
            {
                return false;
            }
            _users.Remove(user);
            return true;
        }
    }
}
