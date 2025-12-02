using Robust.Shared.Serialization;

namespace Content.Shared._Orion.UserInterface.Events;

//
// License-Identifier: GPL-3.0-or-later
//

[Serializable, NetSerializable]
public sealed class RequestedNotesTextEvent(string notesText) : EntityEventArgs
{
    public string NotesText { get; } = notesText;
}
