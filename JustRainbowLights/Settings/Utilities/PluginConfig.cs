using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace JustRainbowLights.Settings.Utilities
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public bool Enabled = true;
        public string Preset = "Original";
    }
}
