using d20TG.Domain;

namespace d20TG.Features.ScenarioSetup.State;

public record DamageDiceState(int diceCount, DiceType diceType);