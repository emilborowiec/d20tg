using d20TG.Domain;

namespace d20TG.Features.Scenarios.Model;

public class AttackerLabeledBuild : AttackerBuild, ILabeledBuild
{
    public string Label { get; set; } = "Attacker";
    public string ColorHex { get; set; } = "#FF0000";
}