using JustRainbowLights.Utilities;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace JustRainbowLights.Data
{
    public class Preset : ColorSO
    {
        public string Name;
        public string Description;
        public Texture2D Icon;

        //Colors
        public Color Color1;
        public Color Color2;

        public Preset(string name, string description, Texture2D icon, Color color1, Color color2)
        {
            Name = name;
            Description = description;
            Icon = icon;

            Color1 = color1;
            Color2 = color2;
        }

        public void Init(Dictionary<string, object> jsonData)
        {
            Name = jsonData["name"].ToString();
            Description = jsonData["description"].ToString();

            try
            {
                byte[] iconData = Utils.LoadFromResource($"JustRainbowLights.Resources.Images.{jsonData["icon"].ToString()}");
                Icon = Utils.LoadTextureRaw(iconData);
            }
            catch
            {
                Plugin.log.Warn("Could not load texture, reverting to default.");
                Icon = Utils.GetDefaultIcon();
            }
            
            var c1Dic = (JObject)jsonData["color1"];
            Color color1 = new Color((float)c1Dic["r"], (float)c1Dic["g"], (float)c1Dic["b"], (float)c1Dic["a"]);
            Color1 = color1;

            var c2Dic = (JObject)jsonData["color2"];
            Color color2 = new Color((float)c2Dic["r"], (float)c2Dic["g"], (float)c2Dic["b"], (float)c2Dic["a"]);
            Color2 = color2;
        }

        public override Color color
        {
            get
            {
                return new Color(Random.Range(Color1.r, Color2.r), Random.Range(Color1.g, Color2.g), Random.Range(Color1.b, Color2.b), Random.Range(Color1.a, Color2.a));
            }
        }
    }
}
