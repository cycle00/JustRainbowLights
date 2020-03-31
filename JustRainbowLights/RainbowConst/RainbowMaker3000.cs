using UnityEngine;

namespace JustRainbowLights.RainbowConst
{
    public class RainbowMaker3000 : ColorSO
    {
        public RainbowDescriptor Descriptor = new RainbowDescriptor()
        {
            Name = "Original",
            Description = "The preset that can generate any colour!",
            Icon = Plugin.LoadIcon("raiinbow.png")
        };

        public override Color color
        {
            get
            {
                return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0.65f, 0.82f));
            }
        }
    }

    public class WarmthGiver3000 : ColorSO
    {
        public RainbowDescriptor Descriptor = new RainbowDescriptor()
        {
            Name = "Warm",
            Description = "This preset only generates warm colours.",
            Icon = Plugin.LoadIcon("warm.png")
        };

        public override Color color
        {
            get
            {
                return new Color(Random.Range(0.5f, 1f), Random.Range(0f, 0.48f), Random.Range(0f, 0.1f), Random.Range(0.65f, 0.82f));
            }
        }
    }

    public class MinecraftIceBlock : ColorSO
    {
        public RainbowDescriptor Descriptor = new RainbowDescriptor()
        {
            Name = "Cool",
            Description = "This preset generates cool colours, which remind me of a minecraft ice block because it is blue, and cold.",
            Icon = Plugin.LoadIcon("cold.png")
        };

        public override Color color
        {
            get
            {
                return new Color(Random.Range(0f, 0.2f), Random.Range(0f, 1f), Random.Range(0.5f, 1f), Random.Range(0.65f, 0.82f));
            }
        }
    }

    public class PastelPainting : ColorSO
    {
        public RainbowDescriptor Descriptor = new RainbowDescriptor()
        {
            Name = "Pastel",
            Description = "This is like the Original preset, but lighter!",
            Icon = Plugin.LoadIcon("pastel.png")
        };

        public override Color color
        {
            get
            {
                return new Color(Random.Range(0.6f, 1f), Random.Range(0.6f, 1f), Random.Range(0.6f, 1f), Random.Range(0.65f, 0.82f));
            }
        }
    }

    public class DarknessInside : ColorSO
    {
        public RainbowDescriptor Descriptor = new RainbowDescriptor()
        {
            Name = "Dark",
            Description = "As the name suggests, it's like the original preset, but darker.",
            Icon = Plugin.LoadIcon("dark.png")
        };

        public override Color color
        {
            get
            {
                return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0.1f, 0.2f));
            }
        }
    }
}
//A MAN HAS FALLEN INTO THE RIVER IN LEGO CITY