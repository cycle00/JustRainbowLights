using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRainbowLights.Config.LiteralUI
{
    class RainbowsInModifiers : NotifiableSingleton<RainbowsInModifiers>
    {
        [UIValue("enableToggle")]
        public bool Enable
        {
            get => PluginConfig.Instance.Enabled;
            set
            {
                PluginConfig.Instance.Enabled = value;
            }
        }

        [UIAction("setEnableToggle")]
        void SetEnable(bool val)
        {
            Enable = val;
        }

        [UIValue("presets")]
        private List<object> presets = (new object[] { Preset.Original, Preset.Warm, Preset.Cool, Preset.Pastel, Preset.Dark }).ToList();

        private Preset ps;
        [UIValue("rp")]
        public Preset Presets
        {
            get => ps;
            set
            {
                ps = value;
                PluginConfig.Instance.Preset = ps.ToString();
            }
        }

        [UIAction("setPreset")]
        void SetPreset(Preset pres)
        {
            Presets = pres;
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
