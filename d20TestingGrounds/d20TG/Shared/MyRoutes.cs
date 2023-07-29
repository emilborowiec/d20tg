namespace d20TG.Shared;

public static class MyRoutes
{
    public const string ScenarioRouteBase = "scenario/";
    public const string NewScenarioRoute = "scenario/new";
    public const string ScenarioRoute = $"{ScenarioRouteBase}{ScenarioIdParam}/";
    public const string ScenarioSimulationRoute = $"{ScenarioRoute}simulation/";
    public const string ScenarioAttackerRoute = $"{ScenarioRoute}attacker/{AttackerBuildIdParam}/";
    public const string ScenarioDefenderRoute = $"{ScenarioRoute}defender/{DefenderBuildIdParam}/";
    
    
    public const string ScenarioIdParam = "{scenarioId}";
    public const string AttackerBuildIdParam = "{attackerBuildId}";
    public const string DefenderBuildIdParam = "{defenderBuildId}";
}