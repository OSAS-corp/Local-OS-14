using System.Numerics;
using Content.Client.Eui;
using Content.Shared._Orion.Skills.Ui;
using Content.Shared.Eui;
using JetBrains.Annotations;
using Robust.Client.Graphics;

namespace Content.Client._Orion.Skills.Ui;

//
// License-Identifier: GPL-3.0-or-later
//

[UsedImplicitly]
public sealed class SkillsEui : BaseEui
{
    private readonly SkillsForcedWindow _window;

    public SkillsEui()
    {
        _window = new SkillsForcedWindow();

        _window.OnClose += () =>
        {
            SendMessage(new SkillsEuiClosedMessage());
        };

        _window.OnSkillChanged += (jobId, skillKey, newLevel) =>
        {
            SendMessage(new SkillsEuiSkillChangedMessage(jobId, skillKey, newLevel));
        };
    }

    public override void Opened()
    {
        IoCManager.Resolve<IClyde>().RequestWindowAttention();
        _window.OpenCenteredAt(new Vector2(0.5f, 0.75f));
    }

    public override void Closed()
    {
        _window.Close();
    }

    public override void HandleState(EuiStateBase state)
    {
        base.HandleState(state);

        if (state is SkillsEuiState skillsState)
        {
            _window.UpdateState(skillsState);
        }
    }
}
