﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace d20TG.Domain;

public class AttackerBuild
{
    [Range(-100, 100)]
    public int AttackBonus { get; set; } 
    [Range(-100, 100)]
    public int DamageBonus { get; set; }
    [Required, JsonInclude]
    [ValidateComplexType]
    public DamageDice DamageDice { get; set; } = new();

    public override string ToString()
    {
        return $"Attack: {AttackBonus}; Damage {DamageDice} + {DamageBonus}";
    }
}