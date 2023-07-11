using d20TG.Domain;

namespace d20TG.Features.CombatSimulations;

public class Defender
{
    public Defender(DefenderBuild build)
    {
        Build = build;
        CurrentHitPoints = Build.HitPoints;
    }

    public DefenderBuild Build { get; }
    public int CurrentHitPoints { get; set; }
}