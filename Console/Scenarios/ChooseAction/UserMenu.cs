using Console.Results;

namespace Console.Scenarios.ChooseAction;

public class UserMenu : Chooser
{
    public UserMenu(IEnumerable<IScenarioCallout> scenarioCalloutsEnumerable)
        : base(scenarioCalloutsEnumerable, "Choose user action")
    {
    }

    public override IScenarioCallout ScenarioCallout => new MenuByUser();
}