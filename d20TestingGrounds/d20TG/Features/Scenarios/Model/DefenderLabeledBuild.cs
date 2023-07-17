using d20TG.Domain;

namespace d20TG.Features.Scenarios.Model;

public class DefenderLabeledBuild : DefenderBuild, ILabeledBuild
{
    public DefenderLabeledBuild(string id)
    {
        Id = id;
    }

    public string Id { get; }
    public string Label { get; set; } = "Defender";
    public string ColorHex { get; set; } = "#0000FF";
}