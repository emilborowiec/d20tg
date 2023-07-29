using System.ComponentModel.DataAnnotations;
using d20TG.Domain;

namespace d20TG.Features.Scenarios.Model;

public class AttackerLabeledBuild : AttackerBuild, ILabeledBuild
{
    public AttackerLabeledBuild(string id)
    {
        Id = id;
    }

    public string Id { get; }
    [MinLength(1)]
    [MaxLength(20)]
    public string Label { get; set; } = "Attacker";
    public string ColorHex { get; set; } = "#FF0000";
}