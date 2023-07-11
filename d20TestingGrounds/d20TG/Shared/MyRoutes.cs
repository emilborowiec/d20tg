namespace d20TG.Shared;

public static class MyRoutes
{
    public const string ScenarioSimulationRouteBase = "scenario-simulation/";
    public const string ScenarioSimulationRoute = $"{ScenarioSimulationRouteBase}" + "{scenarioId}";
}