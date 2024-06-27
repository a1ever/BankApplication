using Console.Results;

namespace Console.Scenarios.ChooseAction;

public class AdminMenu : Chooser
{
    public AdminMenu(IEnumerable<IScenarioCallout> scenarioCalloutsEnumerable)
        : base(scenarioCalloutsEnumerable, "Choose admin action")
    {
    }

    public override IScenarioCallout ScenarioCallout => new MenuByAdmin();
}