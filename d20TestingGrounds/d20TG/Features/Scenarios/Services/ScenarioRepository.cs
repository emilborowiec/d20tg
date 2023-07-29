using Blazored.LocalStorage;
using d20TG.Features.Scenarios.Model;
using d20TG.Features.Scenarios.State;
using d20TG.Features.Scenarios.Utils;

namespace d20TG.Features.Scenarios.Services;

public class ScenarioRepository : IScenarioRepository
{
    private const string ScenariosStorageKey = "scenarios";
    
    private readonly ILocalStorageService _localStorage;
    
    public ScenarioRepository(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<ScenarioId[]> GetAllScenarioIdsAsync()
    {
        var storageInitialized = await _localStorage.ContainKeyAsync(ScenariosStorageKey);
        if (!storageInitialized)
        {
            return Array.Empty<ScenarioId>();
        }

        try
        {
            var scenarios = await LoadScenarios();
            return scenarios.Select(x => new ScenarioId {Id = x.Id, Name = x.Name}).ToArray();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task SaveScenarioAsync(Scenario scenario)
    {
        try
        {
            var scenarios = await LoadScenarios();
            var existingScenario = scenarios.FirstOrDefault(x => x.Id == scenario.Id);
            if (existingScenario != null)
            {
                scenarios.Remove(existingScenario);
            }
            scenarios.Add(scenario);
            
            await _localStorage.SetItemAsync(ScenariosStorageKey, scenarios);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private async Task<List<Scenario>> LoadScenarios()
    {
        var scenarios =
            await _localStorage.GetItemAsync<List<Scenario>>(ScenariosStorageKey) ?? new List<Scenario>();
        return scenarios;
    }

    public async Task<Scenario?> LoadScenarioAsync(string id)
    {
        try
        {
            var scenarios = await LoadScenarios();
            return scenarios.FirstOrDefault(x => x.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task DeleteScenarioAsync(string id)
    {
        try
        {
            var scenarios = await LoadScenarios();
            scenarios.RemoveAll(x => x.Id == id);
            await _localStorage.SetItemAsync(ScenariosStorageKey, scenarios);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task AddOrUpdateAttackerBuildAsync(string scenarioId, AttackerBuildState attackerBuildState)
    {
        var scenario = await LoadScenarioAsync(scenarioId);
        if (scenario == null)
        {
            throw new InvalidOperationException(
                $"Failed to save attacker build to scenario {scenarioId}. Scenario not found.");
        }
        var attacker = scenario.AttackerBuilds.FirstOrDefault(x => x.Id == attackerBuildState.Id);
        if (attacker == null)
        {
            var newAttacker = new AttackerLabeledBuild(attackerBuildState.Id);
            newAttacker.UpdateAttackerFromReadOnlyState(attackerBuildState);
            scenario.AttackerBuilds.Add(newAttacker);
        }
        else
        {
            attacker.UpdateAttackerFromReadOnlyState(attackerBuildState);            
        }
        await SaveScenarioAsync(scenario);
    }

    public async Task AddOrUpdateDefenderBuildAsync(string scenarioId, DefenderBuildState defenderBuildState)
    {
        var scenario = await LoadScenarioAsync(scenarioId);
        if (scenario == null)
        {
            throw new InvalidOperationException(
                $"Failed to save defender build to scenario {scenarioId}. Scenario not found.");
        }
        var defender = scenario.DefenderBuilds.FirstOrDefault(x => x.Id == defenderBuildState.Id);
        if (defender == null)
        {
            var newDefender = new DefenderLabeledBuild(defenderBuildState.Id);
            newDefender.UpdateDefenderFromReadOnlyState(defenderBuildState);
            scenario.DefenderBuilds.Add(newDefender);
        }
        else
        {
            defender.UpdateDefenderFromReadOnlyState(defenderBuildState);            
        }
        await SaveScenarioAsync(scenario);
    }
}