using d20TG.Domain;
using d20TG.Features.ScenarioSetup.State;

namespace d20TG.Features.ScenarioSetup.Services;

public interface ICombatScenarioService
{
    CombatScenarioState GetCurrentState();
    void SetDamageDiceCount(int value);
    void SetDamageDiceType(DiceType newDiceType);
    void SetAttackBonus(int value);
    void SetDamageBonus(int value);
    void SetArmorClass(int value);
    void SetHitPoints(int value);
}