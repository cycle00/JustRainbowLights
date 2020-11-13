using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using JustRainbowLights.Data;
using JustRainbowLights.Settings;
using JustRainbowLights.Utilities;
using HMUI;

namespace JustRainbowLights.UI
{
    internal class PresetMoreViewController : BSMLResourceViewController
    {
        public override string ResourceName => "JustRainbowLights.UI.Views.PresetMore.bsml";

        [UIComponent("preset-description")]
        public TextPageScrollView presetDescription = null;

        [UIValue("enable")]
        public bool Enable
        {
            get => Configuration.Enable;
            set => Configuration.Enable = value;
        }

        public void ChangeDescription(Preset preset)
        {
            presetDescription.SetText($"{preset.Name}:\n\n{Utils.SafeUnescape(preset.Description)}");
        }
    }
}
