using JustRainbowLights.Settings;
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
        public Plugin(IPA.Logging.Logger logger, Config config, PluginMetadata metadata)
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

        [OnStart]
        public void OnStart()
        {
            
        }
        
        [OnExit]
        public void OnQuit()
        {

        }

        private void Load()
        {
            Configuration.Load();

            log.Info($"JustRainbowLights v.{PluginVersion} has successfully loaded");
        }

        private void Unload()
        {
            Configuration.Save();
        }
    }
}
