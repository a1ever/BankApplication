using Console.Results;
using MainLogic.Services;
using Spectre.Console;

namespace BankRunner.Services;

public class ScenarioRunner
{
    private readonly ScenarioFactory _scenarioFactory;

    public ScenarioRunner(IUserService userService, IAdminService adminService)
    {
        _scenarioFactory = new ScenarioFactory(userService, adminService);
    }

    public void Run()
    {
        string nextScenario = Scenario.GetName(new Menu());
        while (!string.IsNullOrEmpty(nextScenario))
        {
            nextScenario = _scenarioFactory.GetScenarioByName(nextScenario).Run();
            AnsiConsole.Clear();
        }
    }
}