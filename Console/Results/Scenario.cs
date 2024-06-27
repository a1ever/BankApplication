namespace Console.Results;

public static class Scenario
{
    public static string GetName(IScenarioCallout scenario)
    {
        return scenario is null ? string.Empty : scenario.Name;
    }
}