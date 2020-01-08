﻿using UnityEngine;

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
                return new Color(Random.Range(0.5f, 1f), Random.Range(0f, 0.48f), Random.Range(0f, 0.1f), Random.Range(0.65f, 0.82f));
            }
        }
    }

    internal class MinecraftIceBlock : SimpleColorSO
    {
        public override Color color
        {
            get
            {
                return new Color(Random.Range(0f, 0.2f), Random.Range(0f, 1f), Random.Range(0.5f, 1f), Random.Range(0.65f, 0.82f));
            }
        }
    }
}
