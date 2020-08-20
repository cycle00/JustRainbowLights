using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JustRainbowLights.Data
{
    public class Descriptor : MonoBehaviour
    {
        public string Name = "Preset Name";
        public string Description = "Preset Description";
        public Texture2D Icon;
        public float R1 = 0f;
        public float R2 = 0f;
        public float G1 = 0f;
        public float G2 = 0f;
        public float B1 = 0f;
        public float B2 = 0f;
        public float A1 = 0f;
        public float A2 = 0f;
    }
}
