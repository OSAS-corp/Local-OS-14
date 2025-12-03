using Content.Shared._Orion.Skills.Prototypes;
using Robust.Shared.Prototypes;
using Robust.Shared.Random;

namespace Content.Shared._Orion.Skills;

//
// License-Identifier: GPL-3.0-or-later
//

public abstract partial class SharedSkillsSystem : EntitySystem
{
    [Dependency] private readonly IPrototypeManager _prototype = default!;
    [Dependency] private readonly IRobustRandom _random = default!;

    public override void Initialize()
    {
        base.Initialize();
        InitializeSkills();
    }

    /// <summary>
    /// Gets a skill prototype by ID.
    /// </summary>
    public SkillPrototype GetSkillPrototype(ProtoId<SkillPrototype> id)
    {
        if (!_prototype.TryIndex(id, out var prototype))
            throw new ArgumentException($"Skill prototype not found: {id}");

        return prototype;
    }

    /// <summary>
    /// Gets an array of costs for a skill.
    /// </summary>
    public int[] GetSkillCost(ProtoId<SkillPrototype> id)
    {
        return GetSkillPrototype(id).Costs;
    }

    /// <summary>
    /// Gets a color for the skill.
    /// </summary>
    public Color GetSkillColor(ProtoId<SkillPrototype> id)
    {
        return GetSkillPrototype(id).Color;
    }
}
