using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Logging;
using BeatSaberMarkupLanguage.Settings;
using IPA.Utilities;
using UnityEngine.SceneManagement;
using UnityEngine;
using JustRainbowLights.Config.LiteralUI;
using JustRainbowLights.Config;
using System.Linq;
using System.Collections;

namespace JustRainbowLights
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public static IPA.Logging.Logger log { get; private set; }
        public static RainbowMaker3000 randColor;
        public static WarmthGiver3000 warmColor;
        public static MinecraftIceBlock coolColor;
        public static PastelPainting pastelColor;
        public static DarknessInside darkColor;
        public static LightSwitchEventEffect[] iSeeLight;
        internal static bool literalRainbows;

        [Init]
        public Plugin(IPA.Logging.Logger logger, IPA.Config.Config conf)
        {
            log = logger;
            randColor = new RainbowMaker3000();
            warmColor = ScriptableObject.CreateInstance<WarmthGiver3000>();
            coolColor = ScriptableObject.CreateInstance<MinecraftIceBlock>();
            pastelColor = ScriptableObject.CreateInstance<PastelPainting>();
            darkColor = ScriptableObject.CreateInstance<DarknessInside>();
            PluginConfig.Instance = conf.Generated<PluginConfig>();
            log.Info("JustRainbowLights has initialized successfully");
        }

        [OnStart]
        public void OnStart()
        {
            BS_Utils.Utilities.BSEvents.menuSceneLoadedFresh += () => BSMLSettings.instance.AddSettingsMenu("JustRainbowLights", "JustRainbowLights.Config.LiteralUI.ToggleInator.bsml", GUIinator.instance);
            BS_Utils.Utilities.BSEvents.gameSceneActive += Rainbows;
        }
        
        [OnExit]
        public void OnQuit()
        {
            BS_Utils.Utilities.BSEvents.gameSceneActive -= Rainbows;
        }

        public void Rainbows()
        {
            if (PluginConfig.Instance.Enabled)
            {
                //A MAN HAS FALLEN INTO THE RIVER IN LEGO CITY
                new GameObject("RainbowReader").AddComponent<MapReader>();
                //HEY!
            }
        }

        public static bool IsChromaInstalled()
        {
            return (IPA.Loader.PluginManager.AllPlugins.Any(x => x.Id == "Chroma" || x.Id == "ChromaLite"));
        }
    }
}
