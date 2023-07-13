namespace d20TG.Features.CombatSimulations;

public class CombatRound
{
    public CombatRound(int roundNumber)
    {
        RoundNumber = roundNumber;
    }
    
    public int RoundNumber { get; }

    public List<CombatTurn> Turns { get; } = new();
}