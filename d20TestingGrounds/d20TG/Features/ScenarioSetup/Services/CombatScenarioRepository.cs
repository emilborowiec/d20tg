using Blazored.LocalStorage;
using d20TG.Features.ScenarioSetup.Model;

namespace d20TG.Features.ScenarioSetup.Services;

public class CombatScenarioRepository : ICombatScenarioRepository
{
    private const string ScenariosStorageKey = "scenarios";
    
    private readonly ILocalStorageService _localStorage;
    
    public CombatScenarioRepository(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<string[]> GetAllScenarioIdsAsync()
    {
        var storageInitialized = await _localStorage.ContainKeyAsync(ScenariosStorageKey);
        if (!storageInitialized)
        {
            return Array.Empty<string>();
        }

        try
        {
            var scenarios =
                await _localStorage.GetItemAsync<Dictionary<string, CombatScenario>>(ScenariosStorageKey);
            return scenarios.Keys.ToArray();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<string> SaveScenarioAsync(CombatScenario combatScenarioState)
    {
        try
        {
            var guid = Guid.NewGuid().ToString();
            var scenarios =
                await _localStorage.GetItemAsync<Dictionary<string, CombatScenario>>(ScenariosStorageKey) ?? new Dictionary<string, CombatScenario>();
            scenarios[guid] = combatScenarioState;
            await _localStorage.SetItemAsync(ScenariosStorageKey, scenarios);
            return guid;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<CombatScenario> LoadScenarioAsync(string guid)
    {
        try
        {
            var scenarios =
                await _localStorage.GetItemAsync<Dictionary<string, CombatScenario>>(ScenariosStorageKey);
            return scenarios[guid];
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task DeleteScenarioAsync(string guid)
    {
        try
        {
            var scenarios =
                await _localStorage.GetItemAsync<Dictionary<string, CombatScenario>>(ScenariosStorageKey);
            scenarios.Remove(guid);
            await _localStorage.SetItemAsync(ScenariosStorageKey, scenarios);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}