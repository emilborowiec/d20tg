using d20TG.Features.Scenarios.Model;
using d20TG.Features.Scenarios.State;
using AttackerBuild = d20TG.Domain.AttackerBuild;
using DamageDice = d20TG.Domain.DamageDice;
using DefenderBuild = d20TG.Domain.DefenderBuild;

namespace d20TG.Features.Scenarios.Utils;

public static class CombatScenarioMappers
{
    public static DamageDiceState ToReadOnlyState(this DamageDice model)
    {
        return new DamageDiceState(model.DiceCount, model.DiceType);
    }

    public static AttackerBuildState ToReadOnlyState(this AttackerBuild model)
    {
        return new AttackerBuildState(model.AttackBonus, model.DamageBonus, model.DamageDice.ToReadOnlyState());
    }

    public static DefenderBuildState ToReadOnlyState(this DefenderBuild model)
    {
        return new DefenderBuildState(model.ArmorClass, model.HitPoints);
    }

    public static CombatScenarioState ToReadOnlyState(this CombatScenario model)
    {
        return new CombatScenarioState(model.Name, model.AttackerBuilds.Select(x => x.ToReadOnlyState()).ToArray(), model.DefenderBuilds.Select(x => x.ToReadOnlyState()).ToArray());
    }
    
    public static void UpdateFromReadOnlyState(this DamageDice damageDice, DamageDiceState damageDiceState)
    {
        damageDice.DiceCount = damageDiceState.DiceCount;
        damageDice.DiceType = damageDiceState.DiceType;
    }
    
        
    public static void UpdateDefenderFromReadOnlyState(this DefenderBuild defenderBuild, DefenderBuildState defenderBuildState)
    {
        defenderBuild.ArmorClass = defenderBuildState.ArmorClass;
        defenderBuild.HitPoints = defenderBuildState.HitPoints;
    }

    public static void UpdateAttackerFromReadOnlyState(this AttackerBuild attackerBuild, AttackerBuildState attackerBuildState)
    {
        attackerBuild.AttackBonus = attackerBuildState.AttackBonus;
        attackerBuild.DamageBonus = attackerBuildState.DamageBonus;
        attackerBuild.DamageDice.UpdateFromReadOnlyState(attackerBuildState.DamageDiceState);
    }

}