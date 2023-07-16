using d20TG.Features.Simulations.Components;

namespace d20TG.Features.Simulations.Model;

public class SimulationRun
{
    public List<CombatRound> Rounds { get; } = new();

    public int TotalDamage => Rounds.Sum(x => x.Turns.Sum(t => t.DamageDelt));
    public decimal DamagePerRound => (decimal)TotalDamage / Rounds.Count;
}