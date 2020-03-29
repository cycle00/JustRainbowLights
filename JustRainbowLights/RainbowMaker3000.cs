using UnityEngine;

namespace JustRainbowLights
{
    public class RainbowMaker3000 : ColorSO
    {
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