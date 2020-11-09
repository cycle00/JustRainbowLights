using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using JustRainbowLights.Data;
using JustRainbowLights.Settings;
using JustRainbowLights.Utilities;
using HMUI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace JustRainbowLights.UI
{
    class PresetListViewController : BSMLResourceViewController
    {
        public override string ResourceName => "JustRainbowLights.UI.Views.PresetList.bsml";
        public Action<Preset> presetChanged;

        [UIComponent("presetList")]
        public CustomListTableData customListTableData = null;

        [UIAction("presetSelect")]
        public void Select(TableView _, int row)
        {
            PresetLoader.SelectedPreset = row;
            Configuration.SelectedPreset = PresetLoader.Presets[row].Name;

            ChangeDescription(row);
        }

        [UIAction("#post-parse")]
        public void SetupList()
        {
            customListTableData.data.Clear();
            foreach (Preset preset in PresetLoader.Presets)
            {
                Sprite sprite = preset?.Icon ? Sprite.Create(preset.Icon, new Rect(Vector2.zero, new Vector2(preset.Icon.width, preset.Icon.height)), new Vector2(0.5f, 0.5f)) : null;
                CustomListTableData.CustomCellInfo customCellInfo = new CustomListTableData.CustomCellInfo(preset.Name, icon: sprite);
                customListTableData.data.Add(customCellInfo);
            }

            customListTableData.tableView.ReloadData();
            int selectedPreset = PresetLoader.SelectedPreset;

            customListTableData.tableView.ScrollToCellWithIdx(selectedPreset, TableViewScroller.ScrollPositionType.Beginning, false);
            customListTableData.tableView.SelectCellWithIdx(selectedPreset);
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            base.DidActivate(firstActivation, addedToHierarchy, screenSystemEnabling);
            Select(customListTableData.tableView, PresetLoader.SelectedPreset);
        }

        protected override void DidDeactivate(bool removedFromHierarchy, bool screenSystemDisabling)
        {
            base.DidDeactivate(removedFromHierarchy, screenSystemDisabling);
        }

        public void ChangeDescription(int selected)
        {
            Preset selectedPreset = PresetLoader.Presets[selected];
            if (selectedPreset != null)
            {
                presetChanged?.Invoke(selectedPreset);
            }
        }
    }
}
