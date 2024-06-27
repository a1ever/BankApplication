using Console.Results;
using MainLogic.Exceptions;
using MainLogic.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class Withdraw : IScenario
{
    private IUserService _userService;

    public Withdraw(IUserService userService)
    {
        _userService = userService;
    }

    public IScenarioCallout ScenarioCallout => new WithdrawByUser();
    public string Run()
    {
        int counter = 0;
        while (counter < 2)
        {
            try
            {
                _userService.Withdraw(AnsiConsole.Prompt(
                    new TextPrompt<int>("Enter how much you wanna[green] withdraw[/]")));
                counter++;
                return Scenario.GetName(new MenuByUser());
            }
            catch (NotEnoughMoneyException e)
            {
                AnsiConsole.WriteLine(e.Message);
            }
        }

        return Scenario.GetName(new MenuByUser());
    }
}