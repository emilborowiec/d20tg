using d20TG.Features.Scenarios.Model;
using d20TG.Features.Scenarios.State;

namespace d20TG.Features.Scenarios.Services;

public interface IScenarioRepository
{
    Task<ScenarioId[]> GetAllScenarioIdsAsync();

    Task SaveScenarioAsync(Scenario scenario);
    Task<Scenario?> LoadScenarioAsync(string id);
    Task DeleteScenarioAsync(string guid);

    Task AddOrUpdateAttackerBuildAsync(string scenarioId, AttackerBuildState attackerBuildState);
    Task AddOrUpdateDefenderBuildAsync(string scenarioId, DefenderBuildState defenderBuildState);
}