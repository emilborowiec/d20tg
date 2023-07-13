using System.ComponentModel.DataAnnotations;

namespace d20TG.Domain;

public class DamageDice
{
    private int _diceCount = 1;
    public DiceType DiceType { get; set; } = DiceType.D6;
    [Range(1, 100)]
    public int DiceCount {
        get => _diceCount;
        set
        {
            if (value is > 0 and < 100)
            {
                _diceCount = value;
            }
        }
    }

    public override string ToString()
    {
        return $"{DiceCount}d{(int)DiceType}";
    }
}