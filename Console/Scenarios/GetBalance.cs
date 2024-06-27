using Console.Results;
using MainLogic.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class GetBalance : IScenario
{
    private readonly IUserService _userService;

    public GetBalance(IUserService userService)
    {
        _userService = userService;
    }

    public IScenarioCallout ScenarioCallout => new GetBalanceByUser();
    public string Run()
    {
        AnsiConsole.Write(new Text($"Your balance {_userService.GetBalance()}\n"));
        AnsiConsole.Write(new Text("Press enter to go back"));
        System.Console.ReadKey();
        return Scenario.GetName(new MenuByUser());
    }
}