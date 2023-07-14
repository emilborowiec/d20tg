using d20TG.Features.Scenarios.Model;

namespace d20TG.Features.Scenarios.Services;

public interface ICombatScenarioRepository
{
    Task<string[]> GetAllScenarioIdsAsync();

    Task<string> SaveScenarioAsync(CombatScenario combatScenarioState);
    Task<CombatScenario> LoadScenarioAsync(string guid);
    Task DeleteScenarioAsync(string guid);
}