using System.ComponentModel.DataAnnotations;
using d20TG.Domain;
using d20TG.Features.ScenarioSetup.State;

namespace d20TG.Features.ScenarioSetup.ViewModels;

public class DamageDiceViewModel
{
    public DiceType DiceType { get; set; } = DiceType.D6;
    [Range(1, 100)]
    public int DiceCount { get; set; } = 1;

    public void UpdateFromState(DamageDiceState damageDiceState)
    {
        DiceCount = damageDiceState.DiceCount;
        DiceType = damageDiceState.DiceType;
    }
}