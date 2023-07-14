using d20TG.Domain;

namespace d20TG.Features.Simulations;

public class CombatTurn
{
    public CombatTurn(Attacker attacker, Defender defender, int attackRoll)
    {
        Attacker = attacker;
        Defender = defender;
        AttackRoll = attackRoll;
    }

    public Attacker Attacker { get; } 
    public Defender Defender { get; }
    public int AttackRoll { get; }
    public int[]? DamageRolls { get; set; }
    public int DefenderHitPoints { get; set; }

    public string Defence => $"{Defender.Build.ArmorClass}";
    public string Attack => $"{AttackRoll} + {Attacker.Build.AttackBonus} = {AttackRoll + Attacker.Build.AttackBonus} ({CombatSystem.IsHit(Defender.Build.ArmorClass, Attacker.Build.AttackBonus, AttackRoll)})";
    public string Damage => DamageRolls != null ? $"{string.Join('+', DamageRolls)} + {Attacker.Build.AttackBonus} = {DamageRolls.Sum() + Attacker.Build.DamageBonus}" : "N/A";
}