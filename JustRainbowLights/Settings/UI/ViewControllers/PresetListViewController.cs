using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using JustRainbowLights.Data;
using HMUI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace JustRainbowLights.Settings.UI.ViewControllers
{
    class PresetListViewController : BSMLResourceViewController
    {
        public override string ResourceName => "JustRainbowLights.Settings.UI.Views.PresetList.bsml";
        public Action<CustomPreset> presetChanged;


    }
}
