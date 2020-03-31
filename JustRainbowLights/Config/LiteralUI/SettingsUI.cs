using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;

namespace JustRainbowLights.Config.LiteralUI
{
    class SettingsUI
    {
        public static RainbowsFlowCoordinator rainbowsFlowCooridinator;
        public static bool created = false;

        public static void CreateMenu()
        {
            if (!created)
            {
                MenuButton menuButton = new MenuButton("JustRainbowLights", "Rainbow Settings In Here!", RainbowMenuButtonPressed, true);
                MenuButtons.instance.RegisterButton(menuButton);
                created = true;
            }
        }

        public static void ShowRainbowsFlow()
        {
            if (rainbowsFlowCooridinator == null)
            {
                rainbowsFlowCooridinator = BeatSaberUI.CreateFlowCoordinator<RainbowsFlowCoordinator>();
            }

            BeatSaberUI.MainFlowCoordinator.PresentFlowCoordinator(rainbowsFlowCooridinator, null, false, false);
        }

        private static void RainbowMenuButtonPressed() => ShowRainbowsFlow();
    }
}
