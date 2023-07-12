using System.ComponentModel.DataAnnotations;
using d20TG.Features.ScenarioSetup.State;

namespace d20TG.Features.ScenarioSetup.ViewModels;

public class CombatScenarioViewModel : IValidatableObject
{
    public List<DefenderBuildViewModel> DefenderBuilds { get; } = new() { new DefenderBuildViewModel()};
    public List<AttackerBuildViewModel> AttackerBuilds { get; } = new() { new AttackerBuildViewModel()};
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (DefenderBuilds.Count < 1)
        {
            yield return new ValidationResult($"Defender builds must contain at least one build",
                new[] { nameof(DefenderBuilds) });
        }
        if (AttackerBuilds.Count < 1)
        {
            yield return new ValidationResult($"Attacker builds must contain at least one build",
                new[] { nameof(AttackerBuilds) });
        }
    }

    public void UpdateDefenderFromState(DefenderBuildState defenderBuildState)
    {
        DefenderBuilds[0].ArmorClass = defenderBuildState.ArmorClass;
        DefenderBuilds[0].HitPoints = defenderBuildState.HitPoints;
    }

    public void UpdateAttackerFromState(AttackerBuildState attackerBuildState)
    {
        AttackerBuilds[0].AttackBonus = attackerBuildState.AttackBonus;
        AttackerBuilds[0].DamageBonus = attackerBuildState.DamageBonus;
        AttackerBuilds[0].DamageDice.UpdateFromState(attackerBuildState.DamageDiceState);
    }
}