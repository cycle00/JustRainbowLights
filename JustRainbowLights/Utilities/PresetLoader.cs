using JustRainbowLights.Data;
using JustRainbowLights.Settings;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace JustRainbowLights.Utilities
{
    public class PresetLoader
    {
        public static bool IsLoaded { get; private set; }
        public static int SelectedPreset { get; internal set; } = 0;
        public static IList<Preset> Presets { get; private set; }
        public static IEnumerable<string> PresetFiles { get; private set; }

        internal static void Load()
        {
            if (!IsLoaded)
            {
                string path = Path.Combine(Plugin.PluginPath, "Presets");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                IEnumerable<string> filter = new List<string> { "*.json" };
                PresetFiles = Utils.GetFileNames(path, filter, SearchOption.AllDirectories, true);
                Plugin.log.Info($"{PresetFiles.Count()} preset file(s) found.");

                Presets = LoadPresets(PresetFiles);
                Plugin.log.Info($"{Presets.Count} presets(s) loaded.");

                if (Configuration.SelectedPreset != null)
                {
                    int presetCount = Presets.Count;
                    for (int i = 0; i < presetCount; i++)
                    {
                        if (Presets[i].Name == Configuration.SelectedPreset)
                        {
                            SelectedPreset = i;
                            break;
                        }
                    }
                }

                IsLoaded = true;
            }
        }

        internal static void Reload()
        {
            Plugin.log.Debug("Reloading presets.");
            Clear();
            Load();
        }

        internal static void Clear()
        {
            int presetCount = Presets.Count;
            for (int i = 0; i < presetCount; i++)
            {
                Presets[i] = null;
            }

            IsLoaded = false;
            SelectedPreset = 0;
            Presets = new List<Preset>();
            PresetFiles = Enumerable.Empty<string>();
        }

        // The actually interesting stuff
        private static IList<Preset> LoadPresets(IEnumerable<string> fileNames)
        {
            IList<Preset> presets = new List<Preset> { };

            IEnumerable<string> embeddedPresets = new List<string>
            {
                "Original.json",
                "Cold.json",
                "Warm.json",
                "Dark.json",
                "Pastel.json",
            };

            foreach (string presetFile in fileNames)
            {
                try
                {
                    string jsonData = File.ReadAllText(Path.Combine(Plugin.PluginPath, presetFile));
                    Dictionary<string, object> parsedJsonData = Utils.ParseJsonFromString(jsonData);
                    Preset preset = new Preset(parsedJsonData);
                    if (preset != null)
                    {
                        presets.Add(preset);
                    }
                }
                catch (Exception e)
                {
                    Plugin.log.Warn($"Failed to load preset with name '{presetFile}'");
                    Plugin.log.Warn(e);
                }
            }
            
            foreach (string embeddedPreset in embeddedPresets)
            {
                Preset preset = LoadEmbeddedPreset(embeddedPreset);
                if (preset != null)
                {
                    presets.Add(preset);
                }
            }

            return presets;
        }

        private static Preset LoadEmbeddedPreset(string fileName)
        {
            Preset preset = null;

            if (!File.Exists(Path.Combine(Plugin.PluginPath, fileName)))
            {
                File.WriteAllBytes(Plugin.PluginPath, Utils.LoadFromResource($"JustRainbowLights.Data.DefaultPresets.{fileName}"));
                string jsonData = File.ReadAllText(Path.Combine(Plugin.PluginPath, fileName));
                Dictionary<string, object> parsedJsonData = Utils.ParseJsonFromString(jsonData);
                preset = new Preset(parsedJsonData);

                return preset;
            }

            return null;
        }
    }
}
