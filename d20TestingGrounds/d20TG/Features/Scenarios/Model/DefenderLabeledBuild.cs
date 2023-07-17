using d20TG.Domain;

namespace d20TG.Features.Scenarios.Model;

public class DefenderLabeledBuild : DefenderBuild, ILabeledBuild
{
    public string Label { get; set; } = "Defender";
    public string ColorHex { get; set; } = "#0000FF";
}