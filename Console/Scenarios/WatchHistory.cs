using Console.Results;
using MainLogic.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class WatchHistory : IScenario
{
    private IUserService _userService;

    public WatchHistory(IUserService userService)
    {
        _userService = userService;
    }

    public IScenarioCallout ScenarioCallout => new WatchHistoryByUser();
    public string Run()
    {
        Func<bool, string> isRefill = (bool x) => x ? "[green]Refill[/]" : "[red]Withdraw[/]";
        IEnumerable<string> arr = _userService.GetHistory().Select(x => $"{isRefill(x.IsRefill)}: {x.Amount}\n");
        foreach (string s in arr)
        {
            AnsiConsole.Write(new Markup(s));
        }

        AnsiConsole.Write(new Markup($"[grey]------[/]\n"));
        AnsiConsole.Write(new Markup($"[yellow]Total[/]: {_userService.GetBalance()}"));

        Console.ReadKey();
        return Scenario.GetName(new MenuByUser());
    }
}