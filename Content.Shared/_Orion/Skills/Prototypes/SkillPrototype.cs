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
    public SkillType SkillType { get; private set; }

    [DataField(required: true)]
    public int[] Costs { get; private set; } = [0, 0, 0, 0];

    [DataField(required: true)]
    public Color Color { get; private set; } = Color.White;
}
