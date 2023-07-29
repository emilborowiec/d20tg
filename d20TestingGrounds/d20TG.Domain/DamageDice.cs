using System.ComponentModel.DataAnnotations;

namespace d20TG.Domain;

public class DamageDice : IValidatableObject
{
    public DiceType DiceType { get; set; } = DiceType.D6;
    [Range(1, 100)]
    public int DiceCount { get; set; } = 1;

    public override string ToString()
    {
        return $"{DiceCount}d{(int)DiceType}";
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Enum.IsDefined<DiceType>(DiceType))
        {
            yield return new ValidationResult($"DamageDice integral value must be one of 4, 6, 8, 10, 12, 20, 100",
                new[] { nameof(DiceType) });
        }
    }
}