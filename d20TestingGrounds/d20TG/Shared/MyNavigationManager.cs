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
        _navigation.NavigateTo("/");
    }

    public void NavigateToSimulation(string guid)
    {
        _navigation.NavigateTo(MyRoutes.ScenarioSimulationRouteBase + guid);
    }
}