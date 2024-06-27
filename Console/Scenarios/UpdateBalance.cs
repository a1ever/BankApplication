using Console.Results;
using MainLogic.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class UpdateBalance : IScenario
{
    private IUserService _userService;

    public UpdateBalance(IUserService userService)
    {
        _userService = userService;
    }

    public IScenarioCallout ScenarioCallout => new UpdateBalanceByUser();
    public string Run()
    {
        _userService.UpdateBalance(AnsiConsole.Prompt(new TextPrompt<int>("Enter [red]amout to add[/]")));
        return Scenario.GetName(new MenuByUser());
    }
}