using System;
using d20TG.Domain;
using d20TG.Features.Scenarios.Model;
using d20TG.Features.Scenarios.State;
using d20TG.Features.Scenarios.Utils;
using Xunit;

namespace d20TG.Tests.Features.Scenarios.Utils;

public class ScenarioMappersTest
{
    [Fact]
    public void DamageDiceToReadOnlyTest()
    {
        var damageDice = new DamageDice
        {
            DiceCount = 3,
            DiceType = DiceType.D8
        };

        var state = damageDice.ToReadOnlyState();
        
        Assert.Equal(damageDice.DiceCount, state.DiceCount);
        Assert.Equal(damageDice.DiceType, state.DiceType);
    }

    [Fact]
    public void ReadOnlyToDamageDiceTest()
    {
        var state = new DamageDiceState(2, DiceType.D10);

        var damageDice = new DamageDice();
        damageDice.UpdateFromReadOnlyState(state);
        
        Assert.Equal(state.DiceCount, damageDice.DiceCount);
        Assert.Equal(state.DiceType, damageDice.DiceType);
    }

    [Fact]
    public void DefenderBuildToReadOnlyTest()
    {
        var defender = new DefenderLabeledBuild(Guid.NewGuid().ToString())
        {
            Label = "d1",
            ColorHex = "#0000ff",
            ArmorClass = 14,
            HitPoints = 8
        };

        var state = defender.ToReadOnlyState();
        
        Assert.Equal(defender.Id, state.Id);
        Assert.Equal(defender.Label, state.Label);
        Assert.Equal(defender.ColorHex, state.ColorHex);
        Assert.Equal(defender.ArmorClass, state.ArmorClass);
        Assert.Equal(defender.HitPoints, state.HitPoints);
    }
}