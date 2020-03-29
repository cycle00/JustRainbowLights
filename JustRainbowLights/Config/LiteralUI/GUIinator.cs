using BeatSaberMarkupLanguage.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using JustRainbowLights.Config;

namespace JustRainbowLights.Config.LiteralUI
{
    class GUIinator : PersistentSingleton<GUIinator>
    { 
        [UIValue("rainbow")]
        public bool Rainbow
        {
            get => PluginConfig.Instance.Enabled;
            set
            {
                PluginConfig.Instance.Enabled = value;
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
                PluginConfig.Instance.Preset = value.ToString();
            }
        }

        void Awake()
        {
            if (Enum.TryParse(PluginConfig.Instance.Preset, out Preset parsedPreset))
                ps = parsedPreset;
            else
                ps = Preset.Original;
        }
    }
}
/*
 * A MAN HAS FALLEN INTO THE RIVER IN LEGO CITY
 * START THE RESCUE HELICOPTER
 * HEY!
 * BUILD THE HELICOPTER AND OFF TO THE RESCUE
 * PREPARE THE LIFELINE, LOWER THE STRETCHER AND MAKE THE RESCUE
 * THE NEW EMERGENCY COLLECTION FROM LEGO CITY
 */
