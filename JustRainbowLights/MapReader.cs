using IPA.Utilities;
using System.Collections;
using System.Linq;
using UnityEngine;
using JustRainbowLights.Config;
using static JustRainbowLights.Plugin;

namespace JustRainbowLights
{
    internal class MapReader : MonoBehaviour
    {
        private string ps = PluginConfig.Instance.Preset;
        private void Start()
        {
            StartCoroutine(ReadEvents());
        }

        private IEnumerator ReadEvents()
        {
            yield return new WaitUntil(() => Resources.FindObjectsOfTypeAll<LightSwitchEventEffect>().Any());
            
            if (IsChromaInstalled() && IsChromaActive())
            {
                log.Info("Chroma detected, disabling...");
                yield break;
            }

            LightSwitchEventEffect[] iSeeLight = Resources.FindObjectsOfTypeAll<LightSwitchEventEffect>();
            if (iSeeLight == null) yield break;
            
            if (ps == "Original")
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor0", randColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor1", randColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor0", randColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor1", randColor);
                }
            }

            else if (ps == "Warm")
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor0", warmColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor1", warmColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor0", warmColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor1", warmColor);
                }
            }

            else if (ps == "Cool")
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor0", coolColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor1", coolColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor0", coolColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor1", coolColor);
                }
            }

            else if(ps == "Pastel")
            {
                foreach (LightSwitchEventEffect obj in iSeeLight)
                {
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor0", pastelColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor1", pastelColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor0", pastelColor);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor1", pastelColor);
                }
            }

            else if(ps == "Dark")
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
            BeatmapData _beatmapData = s?.GetField<BeatmapData, BeatmapObjectCallbackController>("_beatmapData");
            var beatmap = SongCore.Collections.RetrieveDifficultyData(BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData.difficultyBeatmap).additionalDifficultyData;
            return beatmap._requirements.Contains("Chroma") || beatmap._suggestions.Contains("Chroma")
                || (_beatmapData?.beatmapEventData?.Any(n => n.value >= 2000000000) ?? false);
        }
    }
}
//START THE RESCUE HELICOPTER