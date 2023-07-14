namespace d20TG.Features.Scenarios.State;

public readonly record struct CombatScenarioState(AttackerBuildState[] AttackerBuildStates, DefenderBuildState[] DefenderBuildStates);