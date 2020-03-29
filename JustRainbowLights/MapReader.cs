using IPA.Utilities;
using JustRainbowLights.Config.LiteralUI;
using System.Collections;
using System.Linq;
using UnityEngine;
using static JustRainbowLights.Plugin;

namespace JustRainbowLights
{
    internal class MapReader : MonoBehaviour
    {
        internal static GUIinator gui = GUIinator.instance;

        private void Start()
        {
            StartCoroutine(ReadEvents());
        }

        private IEnumerator ReadEvents()
        {
            yield return new WaitUntil(() => Resources.FindObjectsOfTypeAll<LightSwitchEventEffect>().Any());
            
            if (IsChromaActive() && IsChromaInstalled())
            {
                log.Info("Chroma detected, disabling...");
                yield break;
            }
        
            LightSwitchEventEffect[] iSeeLight = Resources.FindObjectsOfTypeAll<LightSwitchEventEffect>();

            iSeeLight.ToList().ForEach(i => log.Debug(i.ToString()));
            log.Debug(iSeeLight.Count().ToString());

            if (iSeeLight == null) yield break;
            
            if (gui.ps == Preset.Original)
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor0", randColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor1", randColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor0", randColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor1", randColor);
                }
            }

            else if (gui.ps == Preset.Warm)
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor0", warmColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor1", warmColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor0", warmColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor1", warmColor);
                }
            }

            else if (gui.ps == Preset.Cool)
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor0", coolColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor1", coolColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor0", coolColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor1", coolColor);
                }
            }

            else if(gui.ps == Preset.Pastel)
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor0", pastelColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor1", pastelColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor0", pastelColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor1", pastelColor);
                }
            }

            else if(gui.ps == Preset.Dark)
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor0", darkColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor1", darkColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor0", darkColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor1", darkColor);
                }
            }
        }

        public bool IsChromaActive()
        {
            BeatmapObjectCallbackController s = Resources.FindObjectsOfTypeAll<BeatmapObjectCallbackController>().FirstOrDefault();
            if (s == null) return false;
            BeatmapData _beatmapData = ReflectionUtil.GetField<BeatmapData, BeatmapObjectCallbackController>(s, "_beatmapData");
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