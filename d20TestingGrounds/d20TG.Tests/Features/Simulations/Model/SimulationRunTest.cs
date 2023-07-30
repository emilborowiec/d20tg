using d20TG.Features.Simulations.Model;
using Xunit;

namespace d20TG.Tests.Features.Simulations.Model;

public class SimulationRunTest
{
    [Fact]
    public void TotalDamageSumsUpDamageFromAllTurnsAllRounds()
    {
        var run = new SimulationRun(1)
        {
            Rounds =
            {
                new CombatRound(1)
                    { Turns = { CombatTurnTest.CreateCombatTurnSample(), CombatTurnTest.CreateCombatTurnSample() } },
                new CombatRound(2)
                    { Turns = { CombatTurnTest.CreateCombatTurnSample() } },
            }
        };

        var sampleTurn = CombatTurnTest.CreateCombatTurnSample();
        
        Assert.Equal(sampleTurn.DamageDealt * 3, run.TotalDamage);
    }
}