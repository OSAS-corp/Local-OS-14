using Robust.Shared.Serialization;

namespace Content.Shared._Orion.Skills.Events;

//
// License-Identifier: GPL-3.0-or-later
//

[ByRefEvent]
public record struct SkillsAddedEvent();

[Serializable, NetSerializable]
public sealed class SelectSkillPressedEvent : EntityEventArgs
{
    public NetEntity Uid { get; }
    public SkillType Skill { get; }
    public int TargetLevel { get; }
    public string? JobId { get; }

    public SelectSkillPressedEvent(NetEntity uid, SkillType skill, int targetLevel, string? jobId = null)
    {
        Uid = uid;
        Skill = skill;
        TargetLevel = targetLevel;
        JobId = jobId;
    }
}
