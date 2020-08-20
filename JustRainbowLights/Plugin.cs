using IPA;
using IPA.Config;
using UnityEngine;
using System.Linq;
using IPA.Utilities;
using System.IO;
using JustRainbowLights.Settings;
using JustRainbowLights.Settings.UI.ViewControllers;

namespace JustRainbowLights
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        public static string ModPath => Path.Combine(UnityGame.InstallPath, "UserData\\JustRainbowLights");
        public static IPA.Logging.Logger log { get; private set; }

        [Init]
        public void Init(IPA.Logging.Logger logger, [Config.Name("JustRainbowLights/config")] Config conf)
        {
            log = logger;
            Configuration.Init(conf);
            log.Info("JustRainbowLights has initialized");
        }

        [OnEnable]
        public void Enable() => Load();

        [OnDisable]
        public void Disable() => Unload();

        private void Load()
        {
            Configuration.Load();
            BeatSaberMarkupLanguage.GameplaySetup.GameplaySetup.instance.AddTab("JustRainbowLights", "JustRainbowLights.Settings.UI.Views.PresetsModifier.bsml", PresetModifier.instance);
            AddEvents();
        }

        private void Unload()
        {
            RemoveEvents();
            Configuration.Save();
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

        public void OnGameSceneLoaded()
        {

        }

        public static bool IsChromaInstalled()
        {
            return (IPA.Loader.PluginManager.AllPlugins.Any(x => x.Id == "Chroma" || x.Id == "ChromaLite"));
        }
    }
}
