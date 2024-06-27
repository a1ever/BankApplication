using Console.Results;
using MainLogic.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class LogInAdmin : IScenario
{
    private readonly IAdminService _adminService;

    public LogInAdmin(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public IScenarioCallout ScenarioCallout => new AdminLogIn();
    public string Run()
    {
        return !_adminService.LogIn(
            AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [red]password[/]")
                    .Secret('?'))) ? Scenario.GetName(new Menu()) : Scenario.GetName(new MenuByAdmin());
    }
}