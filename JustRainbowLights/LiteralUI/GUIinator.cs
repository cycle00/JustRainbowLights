﻿using BeatSaberMarkupLanguage.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

using static JustRainbowLights.LiteralUI.GUIBiologyClass;

namespace JustRainbowLights.LiteralUI
{
    class GUIinator : PersistentSingleton<GUIinator>
    { 
        [UIValue("rainbow")]
        public bool Rainbow
        {
            get => ModPrefs.GetBool("JustRainbowLights", "literalRainbows", true, false);
            set
            {
                Plugin.literalRainbows = value;
                ModPrefs.SetBool("JustRainbowLights", "literalRainbows", value);
            }
        }

        [UIValue("presets")]
        private List<object> presets = (new object[] { Preset.Original, Preset.Warm, Preset.Cool, Preset.Pastel, Preset.Dark}).ToList();

        public Preset ps;
        [UIValue("rp")]
        public Preset Presets
        {
            get => ps;
            set
            {
                ps = value;
                ModPrefs.SetString("JustRainbowLights", "Preset", ps.ToString());
            }
        }

        void Awake()
        {
            if (Enum.TryParse(ModPrefs.GetString("JustRainbowLights", "Preset", "Original"), out Preset parsedPreset))
                ps = parsedPreset;
            else
                ps = Preset.Original;
        }
    }
}
