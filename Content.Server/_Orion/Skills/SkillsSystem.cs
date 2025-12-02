using Content.Server.EUI;
using Content.Shared._Orion.Skills;
using Content.Shared._Orion.Skills.Components;
using Content.Shared._Orion.Skills.Events;
using Content.Shared.CCVar;
using Content.Shared.Mind;
using Content.Shared.Roles;
using Robust.Shared.Configuration;
using Robust.Shared.Player;

namespace Content.Server._Orion.Skills;

//
// License-Identifier: GPL-3.0-or-later
//

public sealed partial class SkillsSystem : SharedSkillsSystem
{
    [Dependency] private readonly IConfigurationManager _cfg = default!;
    [Dependency] private readonly EuiManager _eui = default!;
    [Dependency] private readonly SharedMindSystem _mind = default!;
    [Dependency] private readonly ISharedPlayerManager _player = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeNetworkEvent<SelectSkillPressedEvent>(OnSelectSkill);
        SubscribeLocalEvent<SkillsComponent, SkillsAddedEvent>(OnSkillsAdded);
    }

    private void OnSelectSkill(SelectSkillPressedEvent args)
    {
        TrySetSkillLevel(GetEntity(args.Uid), args.Skill, args.TargetLevel, args.JobId);
    }

    /// <summary>
    ///     Open skills menu if the player has no skills.
    /// </summary>
    private void OnSkillsAdded(EntityUid uid, SkillsComponent component, SkillsAddedEvent args)
    {
        if (!_cfg.GetCVar(CCVars.SkillsAutoOpenOnSpawn))
            return;

        if (!_mind.TryGetMind(uid, out _, out var mind) || mind is { UserId: null }
            || !_player.TryGetSessionById(mind.UserId, out var session))
            return;

        var jobId = GetJobIdFromEntity(mind);
        if (ShouldForceSkillsSelection(uid, jobId, component))
            OpenForcedSkillsMenu(session, uid, jobId);
    }

    private string? GetJobIdFromEntity(MindComponent mind)
    {
        foreach (var roleId in mind.MindRoles)
        {
            if (!TryComp<MindRoleComponent>(roleId, out var role))
                continue;

            if (role.JobPrototype is { } jobId)
                return jobId.Id;
        }

        return null;
    }

    public void OpenForcedSkillsMenu(ICommonSession player, EntityUid entity, string? jobId)
    {
        jobId ??= "unknown";

        var eui = new SkillsEui(entity, this, jobId);
        _eui.OpenEui(eui, player);

        eui.StateDirty();
    }
}
