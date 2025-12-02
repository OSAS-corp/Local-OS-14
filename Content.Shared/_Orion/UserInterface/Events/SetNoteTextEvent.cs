using Robust.Shared.Serialization;

namespace Content.Shared._Orion.UserInterface.Events;

//
// License-Identifier: GPL-3.0-or-later
//

[Serializable, NetSerializable]
public sealed class SetNoteTextEvent(NetEntity netEntity, string noteText) : EntityEventArgs
{
    public NetEntity Entity { get; } = netEntity;
    public string NoteText { get; } = noteText;
}
