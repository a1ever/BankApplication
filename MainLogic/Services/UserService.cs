using MainLogic.Exceptions;
using MainLogic.Models;
using MainLogic.Repository;

namespace MainLogic.Services;

public class UserService : IUserService
{
    private User? _user;

    public UserService(IUserRepository userRepository, IHistoryRepository historyRepository)
    {
        UserRepository = userRepository;
        HistoryRepository = historyRepository;
    }

    public IUserRepository UserRepository { get; }
    public IHistoryRepository HistoryRepository { get; }

    public bool LogIn(string id, int pin)
    {
        _user = UserRepository.ReadObject(id);
        if (_user is null) return false;

        return _user.Pin == pin;
    }

    public void LogOut()
    {
        _user = null;
    }

    public void UpdateBalance(int amountToAdd)
    {
        if (_user is null) throw new NotLoggedInException();
        _user = _user with { Balance = _user.Balance + amountToAdd };
        HistoryRepository.CreateObject(new Operation(_user.Id, int.Abs(amountToAdd), true));
        UserRepository.UpdateObjectById(_user.Id, _user);
    }

    public int GetBalance()
    {
        if (_user is null) throw new NotLoggedInException();
        return _user.Balance;
    }

    public void Withdraw(int amountToGet)
    {
        if (_user is null) throw new NotLoggedInException();
        int balance = _user.Balance;
        if (balance < amountToGet) throw new NotEnoughMoneyException();
        _user = _user with { Balance = balance - amountToGet };
        HistoryRepository.CreateObject(new Operation(_user.Id, int.Abs(amountToGet), false));
        UserRepository.UpdateObjectById(_user.Id, _user);
    }

    public IEnumerable<Operation> GetHistory()
    {
        if (_user is null) throw new NotLoggedInException();
        return HistoryRepository.ReadObjects();
    }

    public void ChangePin(int newPin)
    {
        if (_user is null) throw new NotLoggedInException();
        _user = _user with { Pin = newPin };
        UserRepository.UpdateObjectById(_user.Id, _user);
    }
}