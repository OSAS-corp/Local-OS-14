// SPDX-FileCopyrightText: 2020 Pieter-Jan Briers <pieterjan.briers+git@gmail.com>
// SPDX-FileCopyrightText: 2021 Acruid <shatter66@gmail.com>
// SPDX-FileCopyrightText: 2021 DrSmugleaf <DrSmugleaf@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Piras314 <p1r4s@proton.me>
// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using System.Linq;
using Content.StyleSheet.Client.StyleSheet;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Shared.Prototypes;

namespace Content.Client.Stylesheets
{
    public sealed class StylesheetManager : IStylesheetManager
    {
        [Dependency] private readonly IUserInterfaceManager _userInterfaceManager = default!;
        [Dependency] private readonly IResourceCache _resourceCache = default!;
        [Dependency] private readonly IPrototypeManager _prototypeManager = default!; // Orion
        [Dependency] private readonly IContentStyleSheetManager _contentStyleSheetManager = default!; // Orion

        private ISawmill _sawmill = default!; // Orion

        public Stylesheet SheetNano { get; private set; } = default!;
        public Stylesheet SheetSpace { get; private set; } = default!;

        public void Initialize()
        {
            // Orion-Edit-Start
            _sawmill = Logger.GetSawmill("StylesheetManager");
            LoadStyles();
            _prototypeManager.PrototypesReloaded += OnPrototypesReloaded;
            // Orion-Edit-End
        }

        // Orion-Start
        private void LoadStyles()
        {
            SheetNano = TryMerge(new StyleNano(_resourceCache).Stylesheet, "nano");
            SheetSpace = TryMerge(new StyleSpace(_resourceCache).Stylesheet, "space");

            _userInterfaceManager.Stylesheet = SheetNano;
        }

        private void OnPrototypesReloaded(PrototypesReloadedEventArgs obj)
        {
            _sawmill.Debug("Reloading styles...");
            LoadStyles();
        }

        private Stylesheet TryMerge(Stylesheet stylesheet, string prefix)
        {
            if (!_prototypeManager.TryIndex<StyleSheetPrototype>(prefix, out var proto))
                return stylesheet;

            var rules = stylesheet.Rules.ToDictionary(r => r.Selector, r => r);
            var newRules = _contentStyleSheetManager.GetStyleRules(proto).ToDictionary(r => r.Selector, r => r);

            var mergedPropsCount = 0;
            var mergedStylesCount = 0;
            var addedStylesCount = 0;

            foreach (var (key,value) in newRules)
            {
                if (rules.TryGetValue(key, out var oriValue))
                {
                    var oriProps = oriValue.Properties.ToDictionary(a => a.Name);
                    foreach (var props in value.Properties)
                    {
                        oriProps[props.Name] = props;
                        mergedPropsCount++;
                    }

                    rules[key] = new(key, oriProps.Values.ToList());
                    mergedStylesCount++;
                }
                else
                {
                    rules[key] = value;
                    addedStylesCount++;
                }
            }

            _sawmill.Debug($"Successfully merged style {prefix}: {mergedPropsCount} props merged and {mergedStylesCount} styles merged and {addedStylesCount} styles added!");

            return new Stylesheet(rules.Values.ToList());
        }
    }
    // Orion-End
}
