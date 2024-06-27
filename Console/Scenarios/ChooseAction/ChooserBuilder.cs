using Console.Results;

namespace Console.Scenarios.ChooseAction;

public class ChooserBuilder
{
    private readonly List<IScenarioCallout> _callouts = new List<IScenarioCallout>();

    public ChooserBuilder WithScenarios(params IScenarioCallout[] scenarioCallout)
    {
        if (scenarioCallout is null) throw new ArgumentNullException(nameof(scenarioCallout));
        foreach (IScenarioCallout callout in scenarioCallout)
        {
            _callouts.Add(callout);
        }

        return this;
    }

    public IEnumerable<IScenarioCallout> Build()
    {
        return _callouts;
    }
}