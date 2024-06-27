using Console.Results;

namespace Console.Scenarios.ChooseAction;

public class MainMenu : Chooser
{
    public MainMenu(IEnumerable<IScenarioCallout> scenarioCalloutsEnumerable)
        : base(scenarioCalloutsEnumerable, "Choose type of account")
    {
    }

    public override IScenarioCallout ScenarioCallout => new Menu();
}