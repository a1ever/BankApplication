using Console.Results;
using MainLogic.Exceptions;
using MainLogic.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class CreateUser : IScenario
{
    private readonly IAdminService _adminService;

    public CreateUser(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public IScenarioCallout ScenarioCallout => new CreateNewUserByAdmin();
    public string Run()
    {
        int counter = 0;
        while (counter < 2)
        {
            try
            {
                _adminService.CreateUser(AnsiConsole.Prompt(
                    new TextPrompt<string>("Enter [green]new username[/]")));
                counter++;
                return Scenario.GetName(new MenuByAdmin());
            }
            catch (AccountAlreadyExistsException e)
            {
                AnsiConsole.WriteLine(e.Message);
            }
        }

        return Scenario.GetName(new MenuByAdmin());
    }
}