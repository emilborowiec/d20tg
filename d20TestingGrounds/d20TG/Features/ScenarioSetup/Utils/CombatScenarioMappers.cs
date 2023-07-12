using d20TG.Features.ScenarioSetup.Model;
using d20TG.Features.ScenarioSetup.State;
using d20TG.Features.ScenarioSetup.ViewModels;
using AttackerBuild = d20TG.Domain.AttackerBuild;
using DamageDice = d20TG.Domain.DamageDice;
using DefenderBuild = d20TG.Domain.DefenderBuild;

namespace d20TG.Features.ScenarioSetup.Utils;

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
        return new CombatScenarioState(model.AttackerBuilds.Select(x => x.ToReadOnlyState()).ToArray(), model.DefenderBuilds.Select(x => x.ToReadOnlyState()).ToArray());
    }
    
    public static DamageDiceState ToReadOnlyState(this DamageDiceViewModel viewModel)
    {
        return new DamageDiceState(viewModel.DiceCount, viewModel.DiceType);
    }

    public static AttackerBuildState ToReadOnlyState(this AttackerBuildViewModel viewModel)
    {
        return new AttackerBuildState(viewModel.AttackBonus, viewModel.DamageBonus, viewModel.DamageDice.ToReadOnlyState());
    }

    public static DefenderBuildState ToReadOnlyState(this DefenderBuildViewModel viewModel)
    {
        return new DefenderBuildState(viewModel.ArmorClass, viewModel.HitPoints);
    }

    public static CombatScenarioState ToReadOnlyState(this CombatScenarioViewModel viewModel)
    {
        return new CombatScenarioState(viewModel.AttackerBuilds.Select(x => x.ToReadOnlyState()).ToArray(), viewModel.DefenderBuilds.Select(x => x.ToReadOnlyState()).ToArray());
    }
}