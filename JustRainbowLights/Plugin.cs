using IPA;
using IPA.Config.Stores;
using UnityEngine;
using JustRainbowLights.Config.LiteralUI;
using JustRainbowLights.Config;
using System.Linq;
using System.Reflection;
using System.IO;
using JustRainbowLights.RainbowConst;

namespace JustRainbowLights
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        public static IPA.Logging.Logger log { get; private set; }
        public static RainbowMaker3000 randColor;
        public static WarmthGiver3000 warmColor;
        public static MinecraftIceBlock coolColor;
        public static PastelPainting pastelColor;
        public static DarknessInside darkColor;

        [Init]
        public Plugin(IPA.Logging.Logger logger, IPA.Config.Config config)
        {
            log = logger;
            PluginConfig.Instance = config.Generated<PluginConfig>();
            randColor = ScriptableObject.CreateInstance<RainbowMaker3000>();
            warmColor = ScriptableObject.CreateInstance<WarmthGiver3000>();
            coolColor = ScriptableObject.CreateInstance<MinecraftIceBlock>();
            pastelColor = ScriptableObject.CreateInstance<PastelPainting>();
            darkColor = ScriptableObject.CreateInstance<DarknessInside>();
            log.Info("JustRainbowLights has initialized successfully");
        }
        
        [OnEnable]
        public void OnEnable()
        {
            SettingsUI.CreateMenu();
            log.Info("Settings have been created");
        }

        [OnStart]
        public void OnStart()
        {
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

        public static byte[] LoadFromResource(string resourcePath)
        {
            return GetResource(Assembly.GetCallingAssembly(), resourcePath);
        }

        public static byte[] GetResource(Assembly assembly, string resourcePath)
        {
            Stream stream = assembly.GetManifestResourceStream(resourcePath);
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, (int)stream.Length);
            return data;
        }

        public static Texture2D LoadIcon(string file)
        {
            Texture2D texture = null;
            byte[] resource = LoadFromResource($"JustRainbowLights.Img.{file}");
            texture = LoadRawTexture(resource);

            return texture;
        }

        public static Texture2D LoadRawTexture(byte[] file)
        {
            if (file.Length > 0)
            {
                Texture2D texture = new Texture2D(2, 2);
                if (texture.LoadImage(file))
                {
                    return texture;
                }
            }
            return null;
        }

        public static bool IsChromaInstalled()
        {
            return (IPA.Loader.PluginManager.AllPlugins.Any(x => x.Id == "Chroma" || x.Id == "ChromaLite"));
        }
    }
}
