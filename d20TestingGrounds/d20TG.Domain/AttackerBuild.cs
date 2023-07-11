namespace d20TG.Domain;

public class AttackerBuild
{
    public int AttackBonus { get; set; } 
    public int DamageBonus { get; set; }
    public DamageDice DamageDice { get; } = new();
}