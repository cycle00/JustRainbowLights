using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;

namespace JustRainbowLights.UI
{
    internal class SettingsUI
    {
        private static readonly MenuButton menuButton = new MenuButton("JustRainbowLigths", "Presets can be found in here!", PresetMenuButtonPressed, true);

        public static PresetsFlowCoordinator presetsFlowCoordinator;
        public static bool created = false;

        public static void CreateMenu()
        {
            if (!created)
            {
                MenuButtons.instance.RegisterButton(menuButton);
                created = true;
            }
        }

        public static void RemoveMenu()
        {
            if (created)
            {
                MenuButtons.instance.UnregisterButton(menuButton);
                created = false;
            }
        }

        public static void ShowPresetsFlow()
        {
            if (presetsFlowCoordinator == null)
            {
                presetsFlowCoordinator = BeatSaberUI.CreateFlowCoordinator<PresetsFlowCoordinator>();
            }

            BeatSaberUI.MainFlowCoordinator.PresentFlowCoordinator(presetsFlowCoordinator);
        }

        private static void PresetMenuButtonPressed() => ShowPresetsFlow();
    }
}
