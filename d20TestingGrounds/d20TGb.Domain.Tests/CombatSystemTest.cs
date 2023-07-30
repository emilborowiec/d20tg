using d20TG.Domain;
using Xunit;

namespace D20Lab.Domain.Tests;

public class CombatSystemTest
{
    [Fact]
    public void AttackBelowArmorClassMisses()
    {
        var result = CombatSystem.IsHit(10, 0, 9);
        Assert.False(result);
    }

    [Fact]
    public void AttackEqualOrHigherThanArmorClassHits()
    {
        var result = CombatSystem.IsHit(10, 0, 10);
        Assert.True(result);
    }

    [Fact]
    public void AttackBonusContributesToHit()
    {
        var result = CombatSystem.IsHit(10, 5, 5);
        Assert.True(result);
    }

    [Fact]
    public void Rolling1MissesRegardlessOfArmorClass()
    {
        var result = CombatSystem.IsHit(10, 20, 1);
        Assert.False(result);
    }

    [Fact]
    public void Rolling20HitsRegardlessOfArmorClass()
    {
        var result = CombatSystem.IsHit(30, 0, 20);
        Assert.True(result);
    }
}