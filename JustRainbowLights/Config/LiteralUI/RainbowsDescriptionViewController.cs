using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using HMUI;
using JustRainbowLights.RainbowConst;

namespace JustRainbowLights.Config.LiteralUI
{
    class RainbowsDescriptionViewController : BSMLResourceViewController
    {
        public override string ResourceName => "JustRainbowLights.Config.LiteralUI.Views.RainbowsMore.bsml";

#pragma warning disable CS0649
        [UIComponent("rainbow-description")]
        public TextPageScrollView rainbowDescription;
#pragma warning restore

        [UIValue("enable")]
        public bool Enable
        {
            get => PluginConfig.Instance.Enabled;
            set => PluginConfig.Instance.Enabled = value;
        }

        public void ChangeDescription(string name, string description)
        {
            rainbowDescription.SetText($"{name}:\n\n{description}");
        }
    }
}
