using MainLogic.Models;
using MainLogic.Repository;

namespace MainLogic.Services;

public interface IAdminService
{
    protected IUserRepository UserRepository { get; }

    bool LogIn(string password);
    void CreateUser(string newId);
    void DeleteUser(string newId);
    IEnumerable<User> GetAllUsers();
}