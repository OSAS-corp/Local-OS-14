using Robust.Client.UserInterface.Controllers;

namespace Content.Client._Orion.Notes;

//
// License-Identifier: GPL-3.0-or-later
//

public sealed class NotesTextUIController : UIController
{
    [Dependency] private readonly IEntityManager _entManager = default!;

    private NotesTextWindow? _notesTextWindow;

    public void OpenWindow()
    {
        if (_notesTextWindow == null || _notesTextWindow.Disposed)
            _notesTextWindow = UIManager.CreateWindow<NotesTextWindow>();

        _entManager.System<NotesTextSystem>().RequestNotesText();
        _notesTextWindow?.OpenCentered();
    }

    public void SetNotesText(string text)
    {
        _notesTextWindow?.SetNotesText(text);
    }
}
