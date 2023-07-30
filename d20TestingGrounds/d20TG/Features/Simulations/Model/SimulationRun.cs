namespace d20TG.Features.Simulations.Model;

public class SimulationRun
{
    public SimulationRun(int id)
    {
        Id = id;
    }

    public int Id { get; }
    public List<CombatRound> Rounds { get; } = new();

    public int TotalDamage => Rounds.Sum(x => x.Turns.Sum(t => t.DamageDealt));
    public decimal DamagePerRound => (decimal)TotalDamage / Rounds.Count;

    public decimal Accurracy
    {
        get
        {
            var allTurns = Rounds.SelectMany(x => x.Turns).ToList();
            var hitTurns = allTurns.Where(x => x.IsHit).ToList();
            return (hitTurns.Count * 100m) / allTurns.Count;
        }
    }

    public static decimal CalculateRoundsToBeatGrandAverage(List<SimulationRun> runs)
    {
        var allRounds = runs.SelectMany(x => x.Rounds).ToList();
        return (decimal)allRounds.Count / runs.Count;
    }

    public static decimal CalculateDamagePerRoundGrandAverage(List<SimulationRun> runs)
    {
        return runs.Sum(x => x.DamagePerRound) / runs.Count;
    }

    public static decimal CalculateAccuracyGrandAverage(List<SimulationRun> runs)
    {
        return runs.Sum(x => x.Accurracy) / runs.Count;
    }

}