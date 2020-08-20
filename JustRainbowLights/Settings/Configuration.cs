using JustRainbowLights.Settings.Utilities;
using IPA.Config;
using IPA.Config.Stores;

namespace JustRainbowLights.Settings
{
    public class Configuration
    {
        public static bool Enable { get; internal set; }
        public static string CurrentlySelectedPreset { get; internal set; }

        internal static void Init(Config conf)
        {
            PluginConfig.Instance = conf.Generated<PluginConfig>();
        }

        internal static void Save()
        {
            PluginConfig.Instance.Enabled = Enable;
            PluginConfig.Instance.Preset = CurrentlySelectedPreset;
        }

        internal static void Load()
        {
            Enable = PluginConfig.Instance.Enabled;
            CurrentlySelectedPreset = PluginConfig.Instance.Preset;
        }
    }
}
