using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace JustRainbowLights.Config
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public bool Enabled = true;
        public string Preset = "Original";
    }
}

//THE NEW EMERGENCY COLLECTION FROM LEGO CITY
