using Console.Results;

namespace Console.Scenarios.ChooseAction;

public class ChooserDirector
{
    private readonly ChooserBuilder _builder = new ChooserBuilder();

    public IEnumerable<IScenarioCallout> MainMenuVariants()
    {
        return _builder.WithScenarios(
            new UserLogIn(),
            new AdminLogIn(),
            new MainExit()).Build();
    }

    public IEnumerable<IScenarioCallout> UserMenuVariants()
    {
        return _builder.WithScenarios(
            new GetBalanceByUser(),
            new UpdateBalanceByUser(),
            new WithdrawByUser(),
            new WatchHistoryByUser(),
            new ChangePinByUser(),
            new LogOutByAnyone()).Build();
    }

    public IEnumerable<IScenarioCallout> AdminMenuVariants()
    {
        return _builder.WithScenarios(
            new CreateNewUserByAdmin(),
            new DeleteUserByAdmin(),
            new Menu()).Build();
    }
}