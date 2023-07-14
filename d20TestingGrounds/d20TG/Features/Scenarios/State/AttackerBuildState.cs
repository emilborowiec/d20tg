namespace d20TG.Features.Scenarios.State;

public readonly record struct AttackerBuildState(int AttackBonus = 0, int DamageBonus = 0, DamageDiceState DamageDiceState = new ());