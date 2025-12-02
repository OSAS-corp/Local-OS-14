using Robust.Shared.Serialization;

namespace Content.Shared._Orion.UserInterface.Events;

//
// License-Identifier: GPL-3.0-or-later
//

[Serializable, NetSerializable]
public sealed class RequestNoteTextEvent(NetEntity entity) : EntityEventArgs
{
    public NetEntity Entity { get; } = entity;
}
