﻿namespace d20TG.Features.Scenarios.Model;

public interface ILabeledBuild
{
    public string Id { get; }
    public string Label { get; set; }
    public string ColorHex { get; set; }
}