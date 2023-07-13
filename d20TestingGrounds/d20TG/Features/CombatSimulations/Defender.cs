using d20TG.Features.ScenarioSetup.State;

namespace d20TG.Features.CombatSimulations;

public class Defender
{
    public Defender(DefenderBuildState build)
    {
        Build = build;
        CurrentHitPoints = Build.HitPoints;
    }

    public DefenderBuildState Build { get; }
    public int CurrentHitPoints { get; set; }
    public bool Alive => CurrentHitPoints > 0;
}