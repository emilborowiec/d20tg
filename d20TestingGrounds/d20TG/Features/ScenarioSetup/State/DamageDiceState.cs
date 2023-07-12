using d20TG.Domain;

namespace d20TG.Features.ScenarioSetup.State;

public readonly record struct DamageDiceState(int DiceCount = 0, DiceType DiceType = DiceType.D6);