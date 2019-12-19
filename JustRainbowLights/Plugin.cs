using IPA;
using IPA.Config;
using BeatSaberMarkupLanguage.Settings;
using IPA.Utilities;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using UnityEngine;
using JustRainbowLights.LiteralUI;

namespace JustRainbowLights
{
    public class Plugin : IBeatSaberPlugin
    {
        private RainbowMaker3000 randColor;
        private WarmthGiver3000 warmColor;
        private MinecraftIceBlock coolColor;
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
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
            BS_Utils.Utilities.BSEvents.menuSceneLoadedFresh += () => BSMLSettings.instance.AddSettingsMenu("JustRainbowLights", "JustRainbowLights.LiteralUI.ToggleInator.bsml", GUIinator.instance);
        }
        
        public void OnApplicationQuit()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            literalRainbows = GUIBiologyClass.ModPrefs.GetBool("JustRainbowLights", "literalRainbows", true, false);

            if (nextScene.name == "MenuViewController")
            {
                BS_Utils.Gameplay.Gamemode.Init();
            }

            iSeeLight = Resources.FindObjectsOfTypeAll<LightSwitchEventEffect>();

            if (iSeeLight != null)
            {
                if(literalRainbows == true)
                {
                    
                    if(gui.ps == Preset.Original)
                    {
                        foreach (LightSwitchEventEffect obj in iSeeLight)
                        {
                            ReflectionUtil.SetPrivateField(obj, "_lightColor0", randColor);
                            ReflectionUtil.SetPrivateField(obj, "_lightColor1", randColor);
                            ReflectionUtil.SetPrivateField(obj, "_highlightColor0", randColor);
                            ReflectionUtil.SetPrivateField(obj, "_highlightColor1", randColor);
                        }
                    }

                    else if(gui.ps == Preset.Warm)
                    {
                        foreach(LightSwitchEventEffect obj in iSeeLight)
                        {
                            ReflectionUtil.SetPrivateField(obj, "_lightColor0", warmColor);
                            ReflectionUtil.SetPrivateField(obj, "_lightColor1", warmColor);
                            ReflectionUtil.SetPrivateField(obj, "_highlightColor0", warmColor);
                            ReflectionUtil.SetPrivateField(obj, "_highlightColor1", warmColor);
                        }
                    }

                    else if(gui.ps == Preset.Cool)
                    {
                        foreach (LightSwitchEventEffect obj in iSeeLight)
                        {
                            ReflectionUtil.SetPrivateField(obj, "_lightColor0", coolColor);
                            ReflectionUtil.SetPrivateField(obj, "_lightColor1", coolColor);
                            ReflectionUtil.SetPrivateField(obj, "_highlightColor0", coolColor);
                            ReflectionUtil.SetPrivateField(obj, "_highlightColor1", coolColor);
                        }
                    }
                }
            }
        }

        #region unused methods
        public void OnFixedUpdate() { }
        public void OnUpdate() { }
        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode) { }
        public void OnSceneUnloaded(Scene scene) { }
        #endregion
    }
}
