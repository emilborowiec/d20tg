using d20TG.Features.ScenarioSetup.Model;

namespace d20TG.Features.ScenarioSetup.Services;

public interface ICombatScenarioRepository
{
    Task<string[]> GetAllScenarioIdsAsync();

    Task<string> SaveScenarioAsync(CombatScenario combatScenarioState);
    Task<CombatScenario> LoadScenarioAsync(string guid);
}