using Console.Results;
using MainLogic.Models;
using MainLogic.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class DeleteUser : IScenario
{
    private readonly IAdminService _adminService;

    public DeleteUser(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public IScenarioCallout ScenarioCallout => new DeleteUserByAdmin();
    public string Run()
    {
        IEnumerable<User> users = _adminService.GetAllUsers();
        IEnumerable<User> enumerable = users.ToList();
        string userToDelete = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Choose account to delete")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more accounts)[/]")
            .AddChoices(enumerable.Select(x => x.Id)));
        _adminService.DeleteUser(enumerable.First(x => x.Id == userToDelete).Id);

        return Scenario.GetName(new MenuByAdmin());
    }
}