using d20TG.Domain;
using d20TG.Features.Scenarios.State;

namespace d20TG.Features.Simulations.Model;

public static class CombatSimulator
{

    public static List<SimulationRun> RunSimulations(int runCount, ScenarioState scenarioState)
    {
        var runs = new List<SimulationRun>();
        for (var i = 0; i < runCount; i++)
        {
            var run = RunSimulation(i+1, scenarioState);
            runs.Add(run);
        }
        return runs;
    }

    private static SimulationRun RunSimulation(int runId, ScenarioState scenarioState)
    {
        var run = new SimulationRun(runId);
        var roundNumber = 0;
        var attackers = scenarioState.AttackerBuildStates.Select(x => new Attacker(x)).ToArray();
        var defenders = scenarioState.DefenderBuildStates.Select(x => new Defender(x)).ToArray();
        while (AnyoneAlive(defenders))
        {
            var round = new CombatRound(roundNumber);
            run.Rounds.Add(round);
            foreach (var attacker in attackers)
            {
                var target = FindLivingDefender(defenders);
                var attackRoll = CombatSystem.RollD20();
                var isHit = CombatSystem.IsHit(target.Build.ArmorClass, attacker.Build.AttackBonus, attackRoll);
                var turn = new CombatTurn(attacker, target, attackRoll);
                round.Turns.Add(turn);
                if (isHit)
                {
                    var damage = CombatSystem.RollDamage(attacker.Build.DamageDiceState.DiceCount, attacker.Build.DamageBonus, attacker.Build.DamageDiceState.DiceType, out var damageRolls);
                    target.CurrentHitPoints -= damage;
                    turn.DamageRolls = damageRolls;
                }
                if (!AnyoneAlive(defenders))
                {
                    break;
                }
            }
            roundNumber++;
        }

        return run;
    }

    private static Defender FindLivingDefender(IEnumerable<Defender> defenders)
    {
        return defenders.First(x => x.Alive);
    }

    private static bool AnyoneAlive(IEnumerable<Defender> defenders)
    {
        return defenders.Any(defender => defender.Alive);
    }
}