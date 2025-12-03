using Content.Shared._Orion.Skills.Prototypes;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Shared._Orion.Skills.Events;

//
// License-Identifier: GPL-3.0-or-later
//

[ByRefEvent]
public record struct SkillsAddedEvent;

[Serializable, NetSerializable]
public sealed class SelectSkillPressedEvent : EntityEventArgs
{
    public NetEntity Uid { get; }
    public ProtoId<SkillPrototype> Skill { get; }
    public int TargetLevel { get; }
    public string? JobId { get; }

    public SelectSkillPressedEvent(NetEntity uid, ProtoId<SkillPrototype> skill, int targetLevel, string? jobId = null)
    {
        Uid = uid;
        Skill = skill;
        TargetLevel = targetLevel;
        JobId = jobId;
    }
}
