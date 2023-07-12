namespace d20TG.Domain;

public class DefenderBuild
{
    public int HitPoints { get; set; } = 6;
    public int ArmorClass { get; set; } = 10;

    public override string ToString()
    {
        return $"AC: {ArmorClass}; HP: {HitPoints}";
    }
}