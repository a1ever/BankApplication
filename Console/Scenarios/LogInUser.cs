using Console.Results;
using MainLogic.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class LogInUser : IScenario
{
    private readonly IUserService _userService;

    public LogInUser(IUserService userService)
    {
        _userService = userService;
    }

    public IScenarioCallout ScenarioCallout => new UserLogIn();
    public string Run()
    {
        int counter = 0;
        while (!_userService.LogIn(
                   AnsiConsole.Prompt(
                   new TextPrompt<string>("Enter [green]username[/]")),
                   AnsiConsole.Prompt(
                   new TextPrompt<int>("Enter [red]pin[/]")
                       .Secret('?'))))
        {
            if (counter++ <= 2) continue;
            return Scenario.GetName(new Menu());
        }

        return Scenario.GetName(new MenuByUser());
    }
}