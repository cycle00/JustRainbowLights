using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using IniParser;
using IniParser.Model;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace JustRainbowLights.Settings.UI.ViewControllers
{
    public class PresetModifier : NotifiableSingleton<PresetModifier>
    {
        [UIValue("enableToggle")]
        public bool Enable
        {
            get => Configuration.Enable;
            set
            {
                Configuration.Enable = value;
            }
        }

        [UIAction("setEnableToggle")]
        void SetEnable(bool val)
        {
            Enable = val;
        }

        [UIValue("presets")]
        private List<object> presets = (new object[] { } ).ToList();

        private string ps;
        [UIValue("pres")]
        public string Presets
        {
            get => ps;
            set
            {
                ps = value;
                Configuration.CurrentlySelectedPreset = ps;
            }
        }

        void Awake()
        {
            DirectoryInfo d = new DirectoryInfo(Path.Combine(Plugin.ModPath, "Presets"));
            FileInfo[] files = d.GetFiles("*.ini");
            var parser = new FileIniDataParser();
            IniData data;
            foreach (var file in files)
            {
                data = parser.ReadFile(file.FullName);
                string name = data["Rainbow"]["Name"];
                presets.Add(name);
            }
        }
    }
}
