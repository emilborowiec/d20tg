using d20TG.Domain;
using d20TG.Features.ScenarioSetup.Utils;
using d20TG.Features.ScenarioSetup.Model;
using d20TG.Features.ScenarioSetup.State;

namespace d20TG.Features.ScenarioSetup.Services;

public class CombatScenarioService : ICombatScenarioService
{
    private readonly CombatScenario _combatScenario;

    public CombatScenarioService()
    {
        _combatScenario = new CombatScenario();
    }

    public CombatScenarioState GetCurrentState()
    {
        Console.WriteLine(_combatScenario);
        return _combatScenario.ToReadOnlyState();
    }

    public void SetDamageDiceCount(int value)
    {
        _combatScenario.AttackerBuilds[0].DamageDice.SetDiceCount(value);
    }

    public void SetAttackBonus(int value)
    {
        _combatScenario.AttackerBuilds[0].AttackBonus = value;
    }

    public void SetDamageBonus(int value)
    {
        _combatScenario.AttackerBuilds[0].DamageBonus = value;
    }

    public void SetArmorClass(int value)
    {
        _combatScenario.DefenderBuilds[0].ArmorClass = value;
    }

    public void SetHitPoints(int value)
    {
        _combatScenario.DefenderBuilds[0].HitPoints = value;
    }

    public void SetDamageDiceType(DiceType newDiceType)
    {
        _combatScenario.AttackerBuilds[0].DamageDice.DiceType = newDiceType;
    }
}