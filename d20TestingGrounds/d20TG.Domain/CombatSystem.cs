namespace d20TG.Domain;

public static class CombatSystem
{
    
    public static bool IsHit(int armorClass, int attackBonus, int roll)
    {
        return roll switch
        {
            20 => true,
            1 => false,
            _ => armorClass <= attackBonus + roll
        };
    }
        
    public static int RollD20()
    {
        return RollDice(DiceType.D20);
    }


    public static int RollDice(DiceType diceType)
    {
        return Random.Shared.Next(1, (int)diceType + 1);
    }

    public static int RollDice(int diceCount, DiceType diceType, out int[] rolls)
    {
        rolls = new int[diceCount];
        for (var i = 0; i < diceCount; i++)
        {
            rolls[i] = RollDice(diceType);
        }

        return rolls.Sum();
    }

    public static int RollDamage(int diceCount, int damageBonus, DiceType diceType, out int[] rolls)
    {
        return RollDice(diceCount, diceType, out rolls) + damageBonus;
    }
    
}