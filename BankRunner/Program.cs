using BankRunner.Exceptions;
using BankRunner.Services;
using Database.Entities;
using MainLogic.Services;

namespace BankRunner;

public static class Program
{
    public static void Main()
    {
        string conn = $"Server=localhost;Port={Environment.GetEnvironmentVariable("db_port") ?? throw new NoSuchEnvironmentVariableException()};User Id={Environment.GetEnvironmentVariable("db_user") ?? throw new NoSuchEnvironmentVariableException()};Password={Environment.GetEnvironmentVariable("db_pass") ?? throw new NoSuchEnvironmentVariableException()};Database={Environment.GetEnvironmentVariable("db_name") ?? throw new NoSuchEnvironmentVariableException()};";
        var uRep = new UserRepository(conn);
        var hRep = new HistoryRepository(conn);
        var runner = new ScenarioRunner(
            new UserService(uRep, hRep),
            new AdminService(Environment.GetEnvironmentVariable("admin_password") ?? throw new NoSuchEnvironmentVariableException(), uRep));

        runner.Run();
    }
}