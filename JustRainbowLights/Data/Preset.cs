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

        public override Color color
        {
            get
            {
                return new Color(Random.Range(Color1.r, Color2.r), Random.Range(Color1.g, Color2.g), Random.Range(Color1.b, Color2.b), Random.Range(Color1.a, Color2.a));
            }
        }
    }
}
