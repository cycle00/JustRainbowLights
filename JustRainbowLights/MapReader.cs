using IPA.Utilities;
using JustRainbowLights.LiteralUI;
using System.Collections;
using System.Linq;
using UnityEngine;
using static JustRainbowLights.Plugin;

namespace JustRainbowLights
{
    internal class MapReader : MonoBehaviour
    {
        internal static GUIinator gui = GUIinator.instance;
        private MapColourReader mcr;

        private void Start()
        {
            StartCoroutine(ReadEvents());
            mcr = new GameObject().AddComponent<MapColourReader>();
        }

        private IEnumerator ReadEvents()
        {
            yield return new WaitForSeconds(0f);
            
            if (IsChromaActive() && IsChromaInstalled())
            {
                Logger.log.Info("Chroma detected, disabling...");
                yield break;
            }
        
            LightSwitchEventEffect[] iSeeLight = Resources.FindObjectsOfTypeAll<LightSwitchEventEffect>();
            if (iSeeLight == null) yield break;
            if (mcr.hasCustomLights) yield break;

            if (gui.ps == Preset.Original)
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    ReflectionUtil.SetPrivateField(obj, "_lightColor0", randColor);
                    ReflectionUtil.SetPrivateField(obj, "_lightColor1", randColor);
                    ReflectionUtil.SetPrivateField(obj, "_highlightColor0", randColor);
                    ReflectionUtil.SetPrivateField(obj, "_highlightColor1", randColor);
                }
            }
            else if (gui.ps == Preset.Warm)
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    ReflectionUtil.SetPrivateField(obj, "_lightColor0", warmColor);
                    ReflectionUtil.SetPrivateField(obj, "_lightColor1", warmColor);
                    ReflectionUtil.SetPrivateField(obj, "_highlightColor0", warmColor);
                    ReflectionUtil.SetPrivateField(obj, "_highlightColor1", warmColor);
                }
            }
            else if (gui.ps == Preset.Cool)
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    ReflectionUtil.SetPrivateField(obj, "_lightColor0", coolColor);
                    ReflectionUtil.SetPrivateField(obj, "_lightColor1", coolColor);
                    ReflectionUtil.SetPrivateField(obj, "_highlightColor0", coolColor);
                    ReflectionUtil.SetPrivateField(obj, "_highlightColor1", coolColor);
                }
            }
            else if(gui.ps == Preset.Pastel)
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    ReflectionUtil.SetPrivateField(obj, "_lightColor0", pastelColor);
                    ReflectionUtil.SetPrivateField(obj, "_lightColor1", pastelColor);
                    ReflectionUtil.SetPrivateField(obj, "_highlightColor0", pastelColor);
                    ReflectionUtil.SetPrivateField(obj, "_highlightColor1", pastelColor);
                }
            }
            else if(gui.ps == Preset.Dark)
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    ReflectionUtil.SetPrivateField(obj, "_lightColor0", darkColor);
                    ReflectionUtil.SetPrivateField(obj, "_lightColor1", darkColor);
                    ReflectionUtil.SetPrivateField(obj, "_highlightColor0", darkColor);
                    ReflectionUtil.SetPrivateField(obj, "_highlightColor1", darkColor);
                }
            }
        }

        public bool IsChromaActive()
        {
            BeatmapObjectCallbackController s = Resources.FindObjectsOfTypeAll<BeatmapObjectCallbackController>().FirstOrDefault();
            if (s == null) return false;
            BeatmapData _beatmapData = s.GetPrivateField<BeatmapData>("_beatmapData");
            if (_beatmapData == null) return false;
            BeatmapEventData[] bevData = _beatmapData.beatmapEventData;
            for (int i = bevData.Length - 1; i >= 0; i--)
            {
                if (bevData[i].value >= 2000000000) return true;
            }

            return false;
        }
    }
}
//START THE RESCUE HELICOPTER