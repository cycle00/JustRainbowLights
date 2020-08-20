namespace JustRainbowLights.Settings.Utilities
{
    public class PluginConfig
    {
        public static PluginConfig Instance { get; set; }

        public bool Enabled = true;
        public string Preset;
        public bool ResetDefaultPresets = true;
    }
}
