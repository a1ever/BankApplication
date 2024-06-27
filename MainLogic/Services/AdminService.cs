using MainLogic.Models;
using MainLogic.Repository;

namespace MainLogic.Services;

public class AdminService : IAdminService
{
    private readonly string _password;

    public AdminService(string password, IUserRepository userRepository)
    {
        _password = password;
        UserRepository = userRepository;
    }

    public IUserRepository UserRepository { get; }
    public bool LogIn(string password)
    {
        return _password == password;
    }

    public void CreateUser(string newId)
    {
        UserRepository.CreateObject(new User(newId, 1111, 0));
    }

    public void DeleteUser(string newId)
    {
        UserRepository.DeleteObjectById(newId);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return UserRepository.ReadObjects();
    }
}