using d20TG.Domain;

namespace d20TG.Features.CombatSimulations;

public class Attacker
{
    public Attacker(AttackerBuild build)
    {
        Build = build;
    }

    public AttackerBuild Build { get; }
}