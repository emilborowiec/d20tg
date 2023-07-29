using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using d20TG.Domain;

namespace d20TG.Features.Scenarios.Model;

public class Scenario : IValidatableObject
{
    public Scenario(string id)
    {
        Id = id;
    }

    public const string FirstDefenderId = "defender 1";
    public const string FirstAttackerId = "attacker 1";

    public string Id { get; }
    
    [MinLength(1)]
    [MaxLength(255)]
    public string Name { get; set; } = "New Scenario";
    [JsonInclude]
    [ValidateComplexType]
    public List<DefenderLabeledBuild> DefenderBuilds { get; private set; } = new() { new DefenderLabeledBuild(FirstDefenderId) };
    [JsonInclude]
    [ValidateComplexType]
    public List<AttackerLabeledBuild> AttackerBuilds { get; private set; } = new() { new AttackerLabeledBuild(FirstAttackerId) };

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