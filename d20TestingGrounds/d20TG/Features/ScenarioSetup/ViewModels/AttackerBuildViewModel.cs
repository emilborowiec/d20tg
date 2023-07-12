using System.ComponentModel.DataAnnotations;

namespace d20TG.Features.ScenarioSetup.ViewModels;

public class AttackerBuildViewModel
{
    [Range(-100, 100)]
    public int AttackBonus { get; set; } 
    [Range(-100, 100)]
    public int DamageBonus { get; set; }
    [Required]
    public DamageDiceViewModel DamageDice { get; } = new();

}