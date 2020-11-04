using JustRainbowLights.Settings.Utilities;
using IPA.Config;
using IPA.Config.Stores;

namespace JustRainbowLights.Settings
{
    public class Configuration
    {
        public static string SelectedPreset { get; internal set; }
        public static bool Enable { get; internal set; }

        internal static void Init(Config config)
        {
            PluginConfig.Instance = config.Generated<PluginConfig>();
        }

        internal static void Load()
        {
            SelectedPreset = PluginConfig.Instance.Preset;
            Enable = PluginConfig.Instance.Enabled;
        }

        internal static void Save()
        {
            PluginConfig.Instance.Preset = SelectedPreset;
            PluginConfig.Instance.Enabled = Enable;
        }
    }
}
