using System.ComponentModel.DataAnnotations;
using d20TG.Domain;

namespace d20TG.Features.Scenarios.Model;

public class DefenderLabeledBuild : DefenderBuild, ILabeledBuild
{
    public DefenderLabeledBuild(string id)
    {
        Id = id;
    }

    public string Id { get; }
    [MinLength(1)]
    [MaxLength(20)]
    public string Label { get; set; } = "Defender";
    public string ColorHex { get; set; } = "#0000FF";
}