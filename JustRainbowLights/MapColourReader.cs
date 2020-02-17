using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SongCore.Collections;
using static BS_Utils.Plugin;
using UnityEngine;

namespace JustRainbowLights
{
    public class MapColourReader : MonoBehaviour
    {
        private CustomPreviewBeatmapLevel cpbl;
        public bool hasCustomLights;
        void Awake()
        {
            hasCustomLights = false;
            cpbl = LevelData.GameplayCoreSceneSetupData.difficultyBeatmap.level as CustomPreviewBeatmapLevel;
            
            if (cpbl != null)
            {
                foreach (var i in RetrieveExtraSongData(cpbl.levelID.Substring(13))._difficulties)
                {
                    if (i._colorLeft != null)
                    {
                        hasCustomLights = true;
                    }
                    if (i._colorRight != null)
                    {
                        hasCustomLights = true;
                    }
                    if (i._envColorLeft != null)
                    {
                        hasCustomLights = true;
                    }
                    if (i._envColorRight != null)
                    {
                        hasCustomLights = true;
                    }
                }

            }
        }
    }
}
//HEY!