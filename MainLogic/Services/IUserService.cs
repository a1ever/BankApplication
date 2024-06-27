using MainLogic.Models;
using MainLogic.Repository;

namespace MainLogic.Services;

public interface IUserService
{
    protected IUserRepository UserRepository { get; }
    protected IHistoryRepository HistoryRepository { get; }

    bool LogIn(string id, int pin);
    void LogOut();
    void UpdateBalance(int amountToAdd);
    int GetBalance();
    void Withdraw(int amountToGet);
    IEnumerable<Operation> GetHistory();
    void ChangePin(int newPin);
}