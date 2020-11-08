using JustRainbowLights.Data;
using static JustRainbowLights.Plugin;
using IPA.Utilities;
using UnityEngine;
using System.Collections;
using System.Linq;

namespace JustRainbowLights.Utilities
{
    internal class MapReader : MonoBehaviour
    {
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

            LightSwitchEventEffect[] lights = Resources.FindObjectsOfTypeAll<LightSwitchEventEffect>();
            if (lights == null) yield break;

            Preset preset = PresetLoader.Presets[PresetLoader.SelectedPreset];

            if (preset != null)
            {
                foreach (var obj in lights)
                {
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor0", preset);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_lightColor1", preset);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor0", preset);
                    obj.SetField<LightSwitchEventEffect, ColorSO>("_highlightColor1", preset);
                }
            }
        }

        public bool IsChromaActive()
        {
            var beatmap = SongCore.Collections.RetrieveDifficultyData(BS_Utils.Plugin.LevelData?.GameplayCoreSceneSetupData?.difficultyBeatmap)?.additionalDifficultyData;
            return (beatmap?._requirements?.Contains("Chroma") ?? false) || (beatmap?._suggestions?.Contains("Chroma") ?? false);
        }
    }
}