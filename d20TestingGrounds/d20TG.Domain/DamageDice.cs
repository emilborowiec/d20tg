namespace d20TG.Domain;

public class DamageDice
{
    public DiceType DiceType { get; set; } = DiceType.D6;
    public int DiceCount { get; private set; } = 1;

    public void SetDiceCount(int newDiceCount)
    {
        if (newDiceCount is > 0 and < 100)
        {
            DiceCount = newDiceCount;
        }
    }

    public override string ToString()
    {
        return $"{DiceCount}d{(int)DiceType}";
    }
}