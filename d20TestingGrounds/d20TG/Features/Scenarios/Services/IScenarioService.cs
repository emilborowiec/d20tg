using d20TG.Features.Scenarios.Model;

namespace d20TG.Features.Scenarios.Services;

public interface IScenarioService
{
    Task<AttackerLabeledBuild?> FindAttackerBuildAsync(string scenarioId, string attackerBuildId);
    Task<DefenderLabeledBuild?> FindDefenderBuildAsync(string scenarioId, string defenderBuildId);
}