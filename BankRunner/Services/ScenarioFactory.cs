using Console.Scenarios;
using Console.Scenarios.ChooseAction;
using MainLogic.Services;

namespace BankRunner.Services;

public class ScenarioFactory
{
    private readonly IEnumerable<IScenario> _scenarios;

    public ScenarioFactory(IUserService userService, IAdminService adminService)
    {
        IUserService userService1 = userService;
        IAdminService adminService1 = adminService;
        _scenarios = new List<IScenario>()
        {
            new AdminMenu(new ChooserDirector().AdminMenuVariants()),
            new MainMenu(new ChooserDirector().MainMenuVariants()),
            new UserMenu(new ChooserDirector().UserMenuVariants()),
            new ChangePin(userService1),
            new CreateUser(adminService1),
            new DeleteUser(adminService1),
            new GetBalance(userService1),
            new LogInAdmin(adminService1),
            new LogInUser(userService1),
            new LogOut(userService1),
            new ProgramExit(),
            new UpdateBalance(userService1),
            new WatchHistory(userService1),
            new Withdraw(userService1),
        };
    }

    public IScenario GetScenarioByName(string scenarioName)
    {
        return _scenarios.FirstOrDefault(x => x.ScenarioCallout.Name == scenarioName) ?? throw new ArgumentNullException(scenarioName);
    }
}