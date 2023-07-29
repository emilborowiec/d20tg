using d20TG.Domain;

namespace d20TG.Features.Scenarios.State;

public readonly record struct DamageDiceState(int DiceCount = 1, DiceType DiceType = DiceType.D6);