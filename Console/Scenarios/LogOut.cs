using Console.Results;
using MainLogic.Services;

namespace Console.Scenarios;

public class LogOut : IScenario
{
    private readonly IUserService _userService;

    public LogOut(IUserService userService)
    {
        _userService = userService;
    }

    public IScenarioCallout ScenarioCallout { get; } = new LogOutByAnyone();
    public string Run()
    {
        _userService.LogOut();
        return Scenario.GetName(new Menu());
    }
}