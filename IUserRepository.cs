using System.Collections.Generic;
using EventAPI.Models;

namespace EventAPI.Repositories
{
    public interface IUserRepository
    {
        User CreateUser(User userDetails);
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        User UpdateUser(int id, User userDetails);
        bool DeleteUser(int id);
    }
}
