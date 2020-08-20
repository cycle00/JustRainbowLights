using JustRainbowLights.Data;
using JustRainbowLights.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JustRainbowLights.Utilities
{
    public class PresetLoader
    {
        public static bool IsLoaded { get; private set; }
        public static int SelectedPreset { get; internal set; } = 0;
        public static IList<CustomPreset> CustomPresets { get; private set; }
        public static IEnumerable<string> CustomPresetFiles { get; private set; } = Enumerable.Empty<string>();

        internal static void Load()
        {
            if (!IsLoaded)
            {
                Directory.CreateDirectory(Plugin.ModPath);

                IEnumerable<string> presetFilter = new List<string> { "*.ini", "*.txt" };
                CustomPresetFiles = Utils.GetFileNames(Plugin.ModPath, presetFilter, SearchOption.AllDirectories, true);
                Plugin.log.Info($"{CustomPresetFiles.Count()} total preset(s) found");

                CustomPresets = LoadCustomPresets(CustomPresetFiles);
                Plugin.log.Info($"{CustomPresets.Count} total preset(s) loaded");

                if (Configuration.CurrentlySelectedPreset != null)
                {
                    int numberOfPresets = CustomPresets.Count;
                    for (int i = 0; i < numberOfPresets; i++)
                    {
                        if (CustomPresets[i].FileName == Configuration.CurrentlySelectedPreset)
                        {
                            SelectedPreset = i;
                            break;
                        }
                    }
                }
            }
        }

        internal static void Reload()
        {
            Plugin.log.Info("Reloading the presets");
            Clear();
            Load();
        }

        internal static void Clear()
        {
            int numberOfPresets = CustomPresets.Count;
            for (int i = 0; i < numberOfPresets; i++)
            {
                CustomPresets[i].Destroy();
                CustomPresets[i] = null;
            }

            IsLoaded = false;
            SelectedPreset = 0;
            CustomPresets = new List<CustomPreset>();
            CustomPresetFiles = Enumerable.Empty<string>();
        }

        private static IList<CustomPreset> LoadCustomPresets(IEnumerable<string> customPresetFiles)
        {
            IList<CustomPreset> customPresets = new List<CustomPreset>
            {

            };

            return customPresets;
        }

        private static CustomPreset LoadEmbeddedPreset(string fileName)
        {
            CustomPreset customPreset = null;
            return customPreset;
        }
    }
}
