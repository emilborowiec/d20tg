using d20TG.Features.ScenarioSetup.Model;
using d20TG.Features.ScenarioSetup.State;
using AttackerBuild = d20TG.Domain.AttackerBuild;
using DamageDice = d20TG.Domain.DamageDice;
using DefenderBuild = d20TG.Domain.DefenderBuild;

namespace d20TG.Features.ScenarioSetup.Utils;

public static class CombatScenarioMappers
{
    public static DamageDiceState ToState(this DamageDice model)
    {
        return new DamageDiceState(model.DiceCount, model.DiceType);
    }

    public static AttackerBuildState ToState(this AttackerBuild model)
    {
        return new AttackerBuildState(model.AttackBonus, model.DamageBonus, model.DamageDice.ToState());
    }

    public static DefenderBuildState ToState(this DefenderBuild model)
    {
        return new DefenderBuildState(model.ArmorClass, model.HitPoints);
    }

    public static CombatScenarioState ToState(this CombatScenario model)
    {
        return new CombatScenarioState(model.AttackerBuilds.Select(x => x.ToState()).ToArray(), model.DefenderBuilds.Select(x => x.ToState()).ToArray());
    }
}