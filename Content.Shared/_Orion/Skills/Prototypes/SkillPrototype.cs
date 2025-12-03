using Robust.Shared.Prototypes;

namespace Content.Shared._Orion.Skills.Prototypes;

//
// License-Identifier: GPL-3.0-or-later
//

[Prototype("skill")]
public sealed partial class SkillPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; private set; } = default!;

    [DataField(required: true)]
    public int[] Costs { get; private set; } = [0, 0, 0, 0];

    [DataField]
    public Color Color { get; private set; } = Color.White;

    /// <summary>
    /// Modifiers for success chance at each skill level.
    /// Used by <see cref="SharedSkillsSystem.CheckSkillChance"/> to calculate the probability of successfully performing an action.
    /// </summary>
    [DataField]
    public Dictionary<int, float> ChanceModifiers { get; private set; } = new()
    {
        { 1, 0.8f },
        { 2, 1.0f },
        { 3, 1.3f },
        { 4, 1.7f },
    };

    /// <summary>
    /// Modifiers for efficiency at each skill level.
    /// Used by <see cref="SharedSkillsSystem.GetSkillEfficiency"/> to calculate performance or bonus effects.
    /// </summary>
    [DataField]
    public Dictionary<int, float> EfficiencyModifiers { get; private set; } = new()
    {
        { 1, 0.7f },
        { 2, 1.0f },
        { 3, 1.4f },
        { 4, 1.8f },
    };
}
