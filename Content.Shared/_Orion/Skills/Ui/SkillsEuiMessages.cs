using Content.Shared._Orion.Skills.Prototypes;
using Content.Shared.Eui;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Shared._Orion.Skills.Ui;

//
// License-Identifier: GPL-3.0-or-later
//

[Serializable, NetSerializable]
public sealed class SkillsEuiState : EuiStateBase
{
    public readonly string JobId;
    public readonly Dictionary<ProtoId<SkillPrototype>, int> CurrentSkills;
    public readonly Dictionary<ProtoId<SkillPrototype>, int> DefaultSkills;
    public readonly int TotalPoints;
    public readonly int SpentPoints;

    public SkillsEuiState(string jobId, Dictionary<ProtoId<SkillPrototype>, int> currentSkills, Dictionary<ProtoId<SkillPrototype>, int> defaultSkills, int totalPoints, int spentPoints)
    {
        JobId = jobId;
        CurrentSkills = currentSkills;
        DefaultSkills = defaultSkills;
        TotalPoints = totalPoints;
        SpentPoints = spentPoints;
    }
}

[Serializable, NetSerializable]
public sealed class SkillsEuiClosedMessage : EuiMessageBase;

[Serializable, NetSerializable]
public sealed class SkillsEuiSkillChangedMessage : EuiMessageBase
{
    public readonly string JobId;
    public readonly ProtoId<SkillPrototype> SkillId;
    public readonly int NewLevel;

    public SkillsEuiSkillChangedMessage(string jobId, ProtoId<SkillPrototype> skillId, int newLevel)
    {
        JobId = jobId;
        SkillId = skillId;
        NewLevel = newLevel;
    }
}

#region Admin
[Serializable, NetSerializable]
public sealed class SkillsAdminEuiState : EuiStateBase
{
    public readonly bool HasSkills;
    public readonly Dictionary<ProtoId<SkillPrototype>, int> CurrentSkills;
    public readonly int SpentPoints;
    public readonly int BonusPoints;
    public readonly string CurrentJob;
    public readonly string EntityName;

    public SkillsAdminEuiState(bool hasSkills, Dictionary<ProtoId<SkillPrototype>, int> currentSkills, int spentPoints, int bonusPoints, string currentJob, string entityName)
    {
        HasSkills = hasSkills;
        CurrentSkills = currentSkills;
        SpentPoints = spentPoints;
        BonusPoints = bonusPoints;
        CurrentJob = currentJob;
        EntityName = entityName;
    }
}

[Serializable, NetSerializable]
public sealed class SkillsAdminEuiClosedMessage : EuiMessageBase;

[Serializable, NetSerializable]
public sealed class SkillsAdminEuiResetMessage : EuiMessageBase;

[Serializable, NetSerializable]
public sealed class SkillsAdminEuiSkillChangedMessage : EuiMessageBase
{
    public readonly ProtoId<SkillPrototype> SkillId;
    public readonly int NewLevel;

    public SkillsAdminEuiSkillChangedMessage(ProtoId<SkillPrototype> skillId, int newLevel)
    {
        SkillId = skillId;
        NewLevel = newLevel;
    }
}

[Serializable, NetSerializable]
public sealed class SkillsAdminEuiPointsChangedMessage : EuiMessageBase
{
    public readonly int NewBonusPoints;

    public SkillsAdminEuiPointsChangedMessage(int newBonusPoints)
    {
        NewBonusPoints = newBonusPoints;
    }
}
#endregion
