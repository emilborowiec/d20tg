using d20TG.Features.Scenarios.State;

namespace d20TG.Features.Simulations;

public class Attacker
{
    public Attacker(AttackerBuildState build)
    {
        Build = build;
    }

    public AttackerBuildState Build { get; }
}