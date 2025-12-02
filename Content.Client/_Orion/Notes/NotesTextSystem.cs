using Content.Shared._Orion.UserInterface.Events;
using Robust.Client.Player;
using Robust.Client.UserInterface;

namespace Content.Client._Orion.Notes;

//
// License-Identifier: GPL-3.0-or-later
//

public sealed partial class NotesTextSystem : EntitySystem
{
    [Dependency] private readonly IEntityManager _ent = default!;
    [Dependency] private readonly IPlayerManager _player = default!;
    [Dependency] private readonly IUserInterfaceManager _userInterfaceManager = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeNetworkEvent<RequestedNotesTextEvent>(OnNotesTextReceived);
    }

    public void RequestNotesText()
    {
        if (!_player.LocalEntity.HasValue)
            return;

        if (!_ent.TryGetNetEntity(_player.LocalEntity.Value, out var netEntity))
            return;

        RaiseNetworkEvent(new RequestNoteTextEvent(netEntity.Value));
    }

    public void OnNotesTextReceived(RequestedNotesTextEvent ev, EntitySessionEventArgs args)
    {
        _userInterfaceManager.GetUIController<NotesTextUIController>().SetNotesText(ev.NotesText);
    }
}
