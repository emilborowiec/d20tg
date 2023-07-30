using System.ComponentModel.DataAnnotations;

namespace d20TG.Features.Scenarios.Model;

public class ScenarioNameFormModel
{
    [MinLength(1), MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}
