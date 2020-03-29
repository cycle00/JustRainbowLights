using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace JustRainbowLights.Config
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public bool Enabled { get; set; } = true;
        public string Preset { get; set; } = "Original";
    }
}

//THE NEW EMERGENCY COLLECTION FROM LEGO CITY
