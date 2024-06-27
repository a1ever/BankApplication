using Console.Results;
using MainLogic.Services;
using Spectre.Console;

namespace Console.Scenarios;

public class ChangePin : IScenario
{
    private const int ImpossiblePin = -1;
    private const int MinPossiblePin = 0;
    private const int MaxPossiblePin = 9999;
    private readonly IUserService _userService;

    public ChangePin(IUserService userService)
    {
        _userService = userService;
    }

    public IScenarioCallout ScenarioCallout => new ChangePinByUser();
    public string Run()
    {
        int pin = ImpossiblePin;
        while (pin is < MinPossiblePin or > MaxPossiblePin)
        {
            pin = AnsiConsole.Prompt(
                new TextPrompt<int>("Enter new [red]pin[/]?")
                    .Secret()
                    .Validate(x =>
                        (x is < MinPossiblePin or > MaxPossiblePin)
                            ? ValidationResult.Error("Pin code must be from 0 to 9999")
                            : ValidationResult.Success()));
        }

        _userService.ChangePin(pin);
        return Scenario.GetName(new MenuByUser());
    }
}