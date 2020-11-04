using JustRainbowLights.Data;
using JustRainbowLights.Settings;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustRainbowLights.Utilities
{
    public class PresetLoader
    {
        public static bool IsLoaded { get; private set; }
        public static IList<Preset> Presets { get; private set; }
        public static IEnumerable<string> PresetFiles { get; private set; }

        public void Load()
        {
            if (!IsLoaded)
            {
                string path = Path.Combine(Plugin.PluginPath, "Presets");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}
