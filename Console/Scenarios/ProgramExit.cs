using Console.Results;

namespace Console.Scenarios;

public class ProgramExit : IScenario
{
    public IScenarioCallout ScenarioCallout { get; } = new MainExit();
    public string Run()
    {
        return string.Empty;
    }
}