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
        public static LightSwitchEventEffect[] iSeeLight;
        internal static bool literalRainbows;

        public void OnApplicationStart()
        {
            randColor = ScriptableObject.CreateInstance<RainbowMaker3000>();
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }

        public void OnApplicationQuit()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void OnFixedUpdate()
        {

        }

        public void OnUpdate()
        {

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
                    foreach (LightSwitchEventEffect obj in iSeeLight)
                    {
                        ReflectionUtil.SetPrivateField(obj, "_lightColor0", randColor);
                        ReflectionUtil.SetPrivateField(obj, "_lightColor1", randColor);
                        ReflectionUtil.SetPrivateField(obj, "_highlightColor0", randColor);
                        ReflectionUtil.SetPrivateField(obj, "_highlightColor1", randColor);
                    }
                }
            }
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            if (scene.name == "MenuViewControllers")
            {
                BSMLSettings.instance.AddSettingsMenu("JustRainbowLights", "JustRainbowLights.LiteralUI.ToggleInator.bsml", GUIinator.instance);
            }
        }

        public void OnSceneUnloaded(Scene scene)
        {

        }
    }
}
