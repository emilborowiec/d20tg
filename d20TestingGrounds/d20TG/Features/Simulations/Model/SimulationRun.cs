namespace d20TG.Features.Simulations.Model;

public class SimulationRun
{
    public SimulationRun(int id)
    {
        Id = id;
    }

    public int Id { get; }
    public List<CombatRound> Rounds { get; } = new();

    public int TotalDamage => Rounds.Sum(x => x.Turns.Sum(t => t.DamageDelt));
    public decimal DamagePerRound => (decimal)TotalDamage / Rounds.Count;
}