using System.ComponentModel.DataAnnotations;

namespace d20TG.Features.ScenarioSetup.ViewModels;

public class DefenderBuildViewModel
{
    [Range(1, 1000)]
    public int HitPoints { get; set; } = 6;
    [Range(0, 100)]
    public int ArmorClass { get; set; } = 10;
}