using d20TG.Features.Scenarios.Model;

namespace d20TG.Features.Scenarios.Services;

public class ScenarioService : IScenarioService
{
    private readonly IScenarioRepository _repository;

    public ScenarioService(IScenarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<AttackerLabeledBuild?> FindAttackerBuildAsync(string scenarioId, string attackerBuildId)
    {
        var scenario = await _repository.LoadScenarioAsync(scenarioId);
        return scenario?.AttackerBuilds.FirstOrDefault(x => x.Id == attackerBuildId);
    }

    public async Task<DefenderLabeledBuild?> FindDefenderBuildAsync(string scenarioId, string defenderBuildId)
    {
        var scenario = await _repository.LoadScenarioAsync(scenarioId);
        return scenario?.DefenderBuilds.FirstOrDefault(x => x.Id == defenderBuildId);
    }
}