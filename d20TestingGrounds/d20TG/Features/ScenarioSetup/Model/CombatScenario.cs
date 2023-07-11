using d20TG.Domain;

namespace d20TG.Features.ScenarioSetup.Model;

public class CombatScenario
{
    public List<DefenderBuild> DefenderBuilds { get; } = new() { new DefenderBuild()};
    public List<AttackerBuild> AttackerBuilds { get; } = new() { new AttackerBuild()};
}