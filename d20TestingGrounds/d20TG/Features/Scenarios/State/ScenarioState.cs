namespace d20TG.Features.Scenarios.State;

public readonly record struct ScenarioState(string Name, AttackerBuildState[] AttackerBuildStates, DefenderBuildState[] DefenderBuildStates);