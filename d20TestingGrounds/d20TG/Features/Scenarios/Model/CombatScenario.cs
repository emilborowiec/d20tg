using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using d20TG.Domain;

namespace d20TG.Features.Scenarios.Model;

public class CombatScenario : IValidatableObject
{
    [JsonInclude]
    public List<DefenderBuild> DefenderBuilds { get; private set; } = new() { new DefenderBuild() };
    [JsonInclude]
    public List<AttackerBuild> AttackerBuilds { get; private set; } = new() { new AttackerBuild() };

    public override string ToString()
    {
        return $"{AttackerBuilds[0]} : {DefenderBuilds[0]}";
    }
    
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
}