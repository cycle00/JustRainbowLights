using IPA;
using IPA.Config;
using BeatSaberMarkupLanguage.Settings;
using IPA.Utilities;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using UnityEngine;
using JustRainbowLights.LiteralUI;
using System.Linq;
using System.Collections;

namespace JustRainbowLights
{
    public class Plugin : IBeatSaberPlugin
    {
        public static RainbowMaker3000 randColor;
        public static WarmthGiver3000 warmColor;
        public static MinecraftIceBlock coolColor;
        public static LightSwitchEventEffect[] iSeeLight;
        internal static bool literalRainbows;
        private static GUIinator gui;

        public void Init(object thisWillBeNull, IPALogger logger)
        {
            Logger.log = logger;
        }

        public void OnApplicationStart()
        {
            randColor = ScriptableObject.CreateInstance<RainbowMaker3000>();
            warmColor = ScriptableObject.CreateInstance<WarmthGiver3000>();
            coolColor = ScriptableObject.CreateInstance<MinecraftIceBlock>();
            gui = new GameObject().AddComponent<GUIinator>();
            BS_Utils.Utilities.BSEvents.menuSceneLoadedFresh += () => BSMLSettings.instance.AddSettingsMenu("JustRainbowLights", "JustRainbowLights.LiteralUI.ToggleInator.bsml", GUIinator.instance);
        }
        
        public void OnApplicationQuit()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            literalRainbows = GUIBiologyClass.ModPrefs.GetBool("JustRainbowLights", "literalRainbows", true, false);

            if (literalRainbows)
            {
                if (nextScene.name == "GameCore")
                {
                    new GameObject("RainbowReader").AddComponent<MapReader>();
                }
            }
        }

        public static bool IsChromaInstalled()
        {
            return (IPA.Loader.PluginManager.AllPlugins.Any(x => x.Metadata.Id == "Chroma" || x.Metadata.Id == "ChromaLite"));
        }

        #region unused methods
        public void OnFixedUpdate() { }
        public void OnUpdate() { }
        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode) { }
        public void OnSceneUnloaded(Scene scene) { }
        #endregion
    }
}
