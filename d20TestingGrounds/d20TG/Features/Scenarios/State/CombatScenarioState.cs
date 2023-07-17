namespace d20TG.Features.Scenarios.State;

public readonly record struct CombatScenarioState(string Name, AttackerBuildState[] AttackerBuildStates, DefenderBuildState[] DefenderBuildStates);