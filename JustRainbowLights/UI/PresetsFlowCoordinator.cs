using BeatSaberMarkupLanguage;
using System;
using HMUI;

namespace JustRainbowLights.UI
{
    internal class PresetsFlowCoordinator : FlowCoordinator
    {
        private PresetListViewController presetListView;
        private PresetMoreViewController presetMoreView;

        public void Awake()
        {
            if (!presetMoreView)
            {
                presetMoreView = BeatSaberUI.CreateViewController<PresetMoreViewController>();
            }

            if (!presetListView)
            {
                presetListView = BeatSaberUI.CreateViewController<PresetListViewController>();

                if (presetMoreView)
                {
                    presetListView.presetChanged += presetMoreView.ChangeDescription;
                }
            }
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            try
            {
                if (firstActivation)
                {
                    SetTitle("JustRainbowLights", ViewController.AnimationType.In);
                    showBackButton = true;
                    ProvideInitialViewControllers(presetListView, presetMoreView);
                }
            }
            catch (Exception e)
            {
                Plugin.log.Error(e);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}
