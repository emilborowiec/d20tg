using d20TG.Features.Scenarios.Model;
using d20TG.Features.Scenarios.State;
using DamageDice = d20TG.Domain.DamageDice;

namespace d20TG.Features.Scenarios.Utils;

public static class ScenarioMappers
{
    public static DamageDiceState ToReadOnlyState(this DamageDice model)
    {
        return new DamageDiceState(model.DiceCount, model.DiceType);
    }

    public static AttackerBuildState ToReadOnlyState(this AttackerLabeledBuild model)
    {
        return new AttackerBuildState(model.Id, model.Label, model.ColorHex, model.AttackBonus, model.DamageBonus, model.DamageDice.ToReadOnlyState());
    }

    public static DefenderBuildState ToReadOnlyState(this DefenderLabeledBuild model)
    {
        return new DefenderBuildState(model.Id, model.Label, model.ColorHex, model.ArmorClass, model.HitPoints);
    }

    public static ScenarioState ToReadOnlyState(this Scenario model)
    {
        return new ScenarioState(model.Name, model.AttackerBuilds.Select(x => x.ToReadOnlyState()).ToArray(), model.DefenderBuilds.Select(x => x.ToReadOnlyState()).ToArray());
    }
    
    public static void UpdateFromReadOnlyState(this DamageDice damageDice, DamageDiceState damageDiceState)
    {
        damageDice.DiceCount = damageDiceState.DiceCount;
        damageDice.DiceType = damageDiceState.DiceType;
    }
    
        
    public static void UpdateDefenderFromReadOnlyState(this DefenderLabeledBuild defenderBuild, DefenderBuildState defenderBuildState)
    {
        defenderBuild.Label = defenderBuildState.Label;
        defenderBuild.ColorHex = defenderBuildState.ColorHex;
        defenderBuild.ArmorClass = defenderBuildState.ArmorClass;
        defenderBuild.HitPoints = defenderBuildState.HitPoints;
    }

    public static void UpdateAttackerFromReadOnlyState(this AttackerLabeledBuild attackerBuild, AttackerBuildState attackerBuildState)
    {
        attackerBuild.Label = attackerBuildState.Label;
        attackerBuild.ColorHex = attackerBuildState.ColorHex;
        attackerBuild.AttackBonus = attackerBuildState.AttackBonus;
        attackerBuild.DamageBonus = attackerBuildState.DamageBonus;
        attackerBuild.DamageDice.UpdateFromReadOnlyState(attackerBuildState.DamageDiceState);
    }

}