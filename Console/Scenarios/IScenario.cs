using Console.Results;

namespace Console.Scenarios;

public interface IScenario
{
    IScenarioCallout ScenarioCallout { get; }
    string Run();
}