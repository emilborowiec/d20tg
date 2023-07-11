using d20TG.Features.ScenarioSetup.State;

namespace d20TG.Features.ScenarioSetup.Services;

public class CombatScenarioRepository : ICombatScenarioRepository
{
    private readonly Dictionary<string, CombatScenarioState> _scenarios = new();
    
    public CombatScenarioState? GetScenarioState(string guid)
    {
        return !_scenarios.ContainsKey(guid) ? null : _scenarios[guid];
    }

    public string SaveScenario(CombatScenarioState combatScenarioState)
    {
        var guid = Guid.NewGuid().ToString();
        _scenarios[guid] = combatScenarioState;
        return guid;
    }
}