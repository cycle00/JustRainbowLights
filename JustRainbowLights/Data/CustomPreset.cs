using JustRainbowLights.Utilities;
using IniParser;
using IniParser.Model;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRainbowLights.Data
{
    public class CustomPreset
    {
        public Descriptor Descriptor { get; }
        public string FileName { get; }

        public CustomPreset(string fileName)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(Path.Combine(Plugin.ModPath, fileName));
            Descriptor = new Descriptor()
            {
                Name = data["Rainbow"]["Name"],
                Description = data["Rainbow"]["Description"],
                Icon = Utils.LoadIcon($"JustRainbowLights.Img.{data["Rainbow"]["Icon"]}"),
                R1 = float.Parse(data["Rainbow"]["R1"]),
                R2 = float.Parse(data["Rainbow"]["R2"]),
                G1 = float.Parse(data["Rainbow"]["G1"]),
                G2 = float.Parse(data["Rainbow"]["G2"]),
                B1 = float.Parse(data["Rainbow"]["R1"]),
                B2 = float.Parse(data["Rainbow"]["B2"]),
                A1 = float.Parse(data["Rainbow"]["A1"]),
                A2 = float.Parse(data["Rainbow"]["A2"])
            };
            FileName = Descriptor.Name;
        }

        public void Destroy()
        {
            UnityEngine.Object.Destroy(Descriptor);
        }
    }
}
