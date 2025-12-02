using Robust.Shared.Configuration;

namespace Content.Shared.CCVar;

//
// License-Identifier: MIT
//

public sealed partial class CCVars
{
    /// <summary>
    ///     Enable or disable skill systems.
    /// </summary>
    public static readonly CVarDef<bool> SkillsEnabled =
        CVarDef.Create("skills.skills_enabled", true, CVar.SERVER | CVar.REPLICATED);

    /// <summary>
    ///     Automatically open the skills selection UI when a player spawns if they have default skills.
    /// </summary>
    public static readonly CVarDef<bool> SkillsAutoOpenOnSpawn =
        CVarDef.Create("skills.auto_open_on_spawn", false, CVar.SERVER | CVar.REPLICATED);
}
