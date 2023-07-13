using d20TG.Features.ScenarioSetup.State;

namespace d20TG.Features.CombatSimulations;

public class Attacker
{
    public Attacker(AttackerBuildState build)
    {
        Build = build;
    }

    public AttackerBuildState Build { get; }
}