using Console.Results;
using Spectre.Console;

namespace Console.Scenarios.ChooseAction;

public abstract class Chooser : IScenario
{
    private readonly string _title;
    private readonly IEnumerable<IScenarioCallout> _scenarioCalloutsEnumerable;

    protected Chooser(IEnumerable<IScenarioCallout> scenarioCalloutsEnumerable, string title)
    {
        _scenarioCalloutsEnumerable = scenarioCalloutsEnumerable;
        _title = title;
    }

    public abstract IScenarioCallout ScenarioCallout { get; }

    public string Run()
    {
        return AnsiConsole.Prompt(new SelectionPrompt<string>().Title(_title)
            .AddChoices(_scenarioCalloutsEnumerable.Select(x => x.Name)));
    }
}