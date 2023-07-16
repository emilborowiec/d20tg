namespace d20TG.Features.Simulations.Model;

public class CombatRound
{
    public CombatRound(int roundNumber)
    {
        RoundNumber = roundNumber;
    }
    
    public int RoundNumber { get; }

    public List<CombatTurn> Turns { get; } = new();
}