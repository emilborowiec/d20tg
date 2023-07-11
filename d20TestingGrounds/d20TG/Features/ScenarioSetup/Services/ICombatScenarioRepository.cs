using d20TG.Features.ScenarioSetup.State;

namespace d20TG.Features.ScenarioSetup.Services;

public interface ICombatScenarioRepository
{
    CombatScenarioState? GetScenarioState(string guid);

    string SaveScenario(CombatScenarioState combatScenarioState);
}