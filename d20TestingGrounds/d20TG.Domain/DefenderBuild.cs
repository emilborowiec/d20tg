using System.ComponentModel.DataAnnotations;

namespace d20TG.Domain;

public class DefenderBuild
{
    [Range(1, 1000)]
    public int HitPoints { get; set; } = 6;
    [Range(0, 100)]
    public int ArmorClass { get; set; } = 10;

    public override string ToString()
    {
        return $"AC: {ArmorClass}; HP: {HitPoints}";
    }
}