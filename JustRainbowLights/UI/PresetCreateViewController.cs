using JustRainbowLights.Data;
using JustRainbowLights.Utilities;
using JustRainbowLights.Settings;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using System.Collections.Generic;
using HMUI;
using UnityEngine;

namespace JustRainbowLights.UI
{
    internal class PresetCreateViewController : BSMLResourceViewController
    {
        public override string ResourceName => "JustRainbowLights.UI.Views.PresetCreate.bsml";

        [UIComponent("iconList")]
        private CustomListTableData iconListTableData;

        [UIComponent("nameKeyboard")]
        private ModalKeyboard nameKeyboard;
        [UIComponent("descriptionKeyboard")]
        private ModalKeyboard descriptionKeyboard;
        [UIComponent("iconButton")]
        private UnityEngine.UI.Button iconButton;
        [UIComponent("redButton")]
        private UnityEngine.UI.Button redButton;
        [UIComponent("greenButton")]
        private UnityEngine.UI.Button greenButton;
        [UIComponent("blueButton")]
        private UnityEngine.UI.Button blueButton;
        [UIComponent("alphaButton")]
        private UnityEngine.UI.Button alphaButton;

        [UIComponent("iconModal")]
        private ModalView iconModal;
        [UIComponent("rModal")]
        private ModalView rModal;
        [UIComponent("gModal")]
        private ModalView gModal;
        [UIComponent("bModal")]
        private ModalView bModal;
        [UIComponent("aModal")]
        private ModalView aModal;

        IList<Sprite> icons = new List<Sprite>();
        IList<string> iconNames = new List<string>()
        {
            "default.png",
            "warm.png",
            "cold.png",
            "dark.png",
            "pastel.png"
        };
        Dictionary<Sprite, string> iconsDictionary = new Dictionary<Sprite, string>();

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            base.DidActivate(firstActivation, addedToHierarchy, screenSystemEnabling);

            if (!firstActivation)
            {
                foreach (string iconName in iconNames)
                {
                    byte[] rawIcon = Utils.LoadFromResource($"JustRainbowLights.Resources.Icons.{iconName}");
                    Texture2D icon = Utils.LoadTextureRaw(rawIcon);
                    icons.Add(Sprite.Create(icon, new Rect(Vector2.zero, new Vector2(icon.width, icon.height)), new Vector2(0.5f, 0.5f)));
                }
                int i = 0;
                foreach (Sprite icon in icons)
                {
                    iconsDictionary.Add(icon, iconNames[i]);
                    i++;
                }
            }
        }

        protected override void DidDeactivate(bool removedFromHierarchy, bool screenSystemDisabling)
        {
            base.DidDeactivate(removedFromHierarchy, screenSystemDisabling);
        }

        [UIAction("#post-parse")]
        public void SetupList()
        {
            iconListTableData.data.Clear();
            foreach (KeyValuePair<Sprite, string> icon in iconsDictionary)
            {
                iconListTableData.data.Add(new CustomListTableData.CustomCellInfo(text: icon.Value, icon: icon.Key));
            }
            iconListTableData.tableView.ReloadData();
        }

        public void UpdatePreset(Preset preset)
        {
            
        }
    }
}
