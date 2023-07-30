using d20TG.Domain;
using d20TG.Features.Scenarios.State;
using d20TG.Features.Simulations.Model;
using Xunit;

namespace d20TG.Tests.Features.Simulations.Model;

public class CombatTurnTest
{
    [Fact]
    public void DamageDealtSumsUpDamageRollsAndDamageBonus()
    {
        var turn = CreateCombatTurnSample();

        Assert.Equal(9, turn.DamageDealt);
    }

    public static CombatTurn CreateCombatTurnSample()
    {
        var attacker =
            new Attacker(new AttackerBuildState("1", "A1", "#0000ff", 1, 3, new DamageDiceState(3, DiceType.D4)));
        var defender = new Defender(new DefenderBuildState("2", "d1", "#ff0000", 13, 10));
        var turn = new CombatTurn(attacker, defender, 20);
        turn.DamageRolls = new[] { 1, 2, 3 };
        return turn;
    }
}