namespace d20TG.Shared;

public interface IMyNavigationManager
{
    void NavigateToHome();
    void NavigateToScenario(string scenarioId);
    void NavigateToNewScenario();
    void NavigateToScenarioSimulation(string scenarioId);
    void NavigateToAttacker(string scenarioId, string attackerId);
    void NavigateToDefender(string scenarioId, string defenderId);
}