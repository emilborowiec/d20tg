namespace d20TG.Features.ScenarioSetup.State;

public readonly record struct CombatScenarioState(AttackerBuildState[] AttackerBuildStates, DefenderBuildState[] DefenderBuildStates);