﻿namespace d20TG.Shared;

public static class MyRoutes
{
    public const string ScenarioSetupRouteBase = "scenario-setup/";
    public const string ScenarioSimulationRouteBase = "scenario-simulation/";
    public const string ScenarioSimulationRoute = $"{ScenarioSimulationRouteBase}" + "{scenarioId}";
}