using BeatSaberMarkupLanguage.Attributes;

namespace JustRainbowLights.LiteralUI
{
    class GUIinator : PersistentSingleton<GUIinator>
    {
        [UIValue("rainbow")]
        public bool Rainbow
        {
            get => GUIBiologyClass.ModPrefs.GetBool("JustRainbowLights", "literalRainbows", true, false);
            set
            {
                Plugin.literalRainbows = value;
                GUIBiologyClass.ModPrefs.SetBool("JustRainbowLights", "literalRainbows", value);
            }
        }
    }
}
