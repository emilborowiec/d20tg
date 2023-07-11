namespace d20TG.Features.CombatSimulations;

public class AttackEvent
{
    public AttackEvent(Attacker attacker, Defender defender, int attackRoll, int damageRoll)
    {
        Attacker = attacker;
        Defender = defender;
        AttackRoll = attackRoll;
        DamageRoll = damageRoll;
    }

    public Attacker Attacker { get; } 
    public Defender Defender { get; }
    public int AttackRoll { get; }
    public int DamageRoll { get; }
}