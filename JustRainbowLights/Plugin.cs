using JustRainbowLights.Data;
using JustRainbowLights.Settings;
using JustRainbowLights.Utilities;
using IPA;
using IPA.Loader;
using IPA.Utilities;
using IPA.Config;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace JustRainbowLights
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public static IPA.Logging.Logger log { get; private set; }
        public static SemVer.Version PluginVersion { get; private set; } = new SemVer.Version("0.0.0");
        public static string PluginPath => Path.Combine(UnityGame.InstallPath, "UserData", "JustRainbowLights");
        
        [Init]
        public void Init(IPA.Logging.Logger logger, Config config, PluginMetadata metadata)
        {
            log = logger;
            Configuration.Init(config);

            if (metadata?.Version != null)
            {
                PluginVersion = metadata.Version;
            }
        }

        [OnEnable]
        public void OnEnable() => Load();

        [OnDisable]
        public void OnDisable() => Unload();

        private void OnGameSceneLoaded()
        {
            if (Configuration.Enable)
            {
                new GameObject("MapReader").AddComponent<MapReader>();
            }
        }

        private void Load()
        {
            Configuration.Load();
            PresetLoader.Load();
            AddEvents();

            log.Info($"JustRainbowLights v.{PluginVersion} has successfully started");
        }

        private void Unload()
        {
            RemoveEvents();
            Configuration.Save();
            PresetLoader.Clear();

        }

        private void AddEvents()
        {
            RemoveEvents();
            BS_Utils.Utilities.BSEvents.gameSceneLoaded += OnGameSceneLoaded;
        }

        private void RemoveEvents()
        {
            BS_Utils.Utilities.BSEvents.gameSceneLoaded -= OnGameSceneLoaded;
        }

        public static bool IsChromaInstalled()
        {
            return PluginManager.EnabledPlugins.Any(x => x.Id == "Chroma" || x.Id == "ChromaLite");
        }
    }
}
