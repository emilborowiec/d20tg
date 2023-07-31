using Microsoft.AspNetCore.Components;

namespace d20TG.Shared;

public class MyNavigationManager : IMyNavigationManager
{
    private readonly NavigationManager _navigation;

    public MyNavigationManager(NavigationManager navigation)
    {
        _navigation = navigation;
    }

    public void NavigateToHome()
    {
        _navigation.NavigateTo(_navigation.BaseUri);
    }

    public void NavigateToScenario(string scenarioId)
    {
        _navigation.NavigateTo(MyRoutes.ScenarioRoute.Replace(MyRoutes.ScenarioIdParam, scenarioId));
    }

    public void NavigateToNewScenario()
    {
        _navigation.NavigateTo(MyRoutes.NewScenarioRoute);
    }

    public void NavigateToScenarioSimulation(string scenarioId)
    {
        _navigation.NavigateTo(MyRoutes.ScenarioSimulationRoute.Replace(MyRoutes.ScenarioIdParam, scenarioId));
    }

    public void NavigateToAttacker(string scenarioId, string attackerId)
    {
        _navigation.NavigateTo(MyRoutes.ScenarioAttackerRoute.Replace(MyRoutes.ScenarioIdParam, scenarioId)
            .Replace(MyRoutes.AttackerBuildIdParam, attackerId));
    }

    public void NavigateToDefender(string scenarioId, string defenderId)
    {
        _navigation.NavigateTo(MyRoutes.ScenarioDefenderRoute.Replace(MyRoutes.ScenarioIdParam, scenarioId)
            .Replace(MyRoutes.DefenderBuildIdParam, defenderId));
    }

}