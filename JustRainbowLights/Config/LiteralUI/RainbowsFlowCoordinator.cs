using BeatSaberMarkupLanguage;
using System;
using HMUI;

namespace JustRainbowLights.Config.LiteralUI
{
    internal class RainbowsFlowCoordinator : FlowCoordinator
    {
        private RainbowsListViewController rainbowsListView;
        private RainbowsDescriptionViewController rainbowsDescriptionView;

        public void Awake()
        {
            if (!rainbowsDescriptionView)
            {
                rainbowsDescriptionView = BeatSaberUI.CreateViewController<RainbowsDescriptionViewController>();
            }

            if (!rainbowsListView)
            {
                rainbowsListView = BeatSaberUI.CreateViewController<RainbowsListViewController>();

                if (rainbowsDescriptionView)
                {
                    rainbowsListView.rainbowChanged += rainbowsDescriptionView.ChangeDescription;
                }
            }
        }

        protected override void DidActivate(bool firstActivation, ActivationType activationType)
        {
            try
            {
                if (firstActivation)
                {
                    title = "JustRainbowLights";
                    showBackButton = true;
                    ProvideInitialViewControllers(rainbowsListView, rainbowsDescriptionView);
                }
            }
            catch (Exception e)
            {
                Plugin.log.Error(e);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this, null, false);
        }
    }
}
/*
 * A MAN HAS FALLEN INTO THE RIVER IN LEGO CITY
 * START THE RESCUE HELICOPTER
 * HEY!
 * BUILD THE HELICOPTER AND OFF TO THE RESCUE
 * PREPARE THE LIFELINE, LOWER THE STRETCHER AND MAKE THE RESCUE
 * THE NEW EMERGENCY COLLECTION FROM LEGO CITY
 */
