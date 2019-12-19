using UnityEngine;

namespace JustRainbowLights
{
    internal class RainbowMaker3000 : SimpleColorSO
    {
        public override Color color
        {
            get
            {
                return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(.65f, .82f));
            }
        }
    }

    internal class WarmthGiver3000 : SimpleColorSO
    {
        public override Color color
        {
            get
            {
                return new Color(Random.Range(0.49f, 1f), Random.Range(0f, 0.75f), 0f, Random.Range(0.65f, 0.82f));
            }
        }
    }

    internal class MinecraftIceBlock : SimpleColorSO
    {
        public override Color color
        {
            get
            {
                return new Color(0, Random.Range(0f, 1f), Random.Range(0.49f, 1f), Random.Range(0.65f, 0.82f));
            }
        }
    }
}
