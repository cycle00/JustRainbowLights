using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using JustRainbowLights.RainbowConst;
using HMUI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace JustRainbowLights.Config.LiteralUI
{
    class RainbowsListViewController : BSMLResourceViewController
    {
        public override string ResourceName => "JustRainbowLights.Config.LiteralUI.Views.RainbowsList.bsml";
        public Action<string, string> rainbowChanged;
        
        private Preset currentPreset = (Preset)Enum.Parse(typeof(Preset), PluginConfig.Instance.Preset);
        private RainbowMaker3000 rO = ScriptableObject.CreateInstance<RainbowMaker3000>();
        private WarmthGiver3000 rW = ScriptableObject.CreateInstance<WarmthGiver3000>();
        private MinecraftIceBlock rC = ScriptableObject.CreateInstance<MinecraftIceBlock>();
        private PastelPainting rP = ScriptableObject.CreateInstance<PastelPainting>();
        private DarknessInside rD = ScriptableObject.CreateInstance<DarknessInside>();

#pragma warning disable CS0649
        [UIComponent("rainbowList")]
        public CustomListTableData customListTableData;
#pragma warning restore

        [UIAction("rainbowSelect")]
        public void Select(TableView _, int row)
        {
            currentPreset = (Preset)row;
            ChangeDescription(row);
        }

        [UIAction("#post-parse")]
        public void SetupList()
        {
            customListTableData.data.Clear();
            List<CustomListTableData.CustomCellInfo> cellInfos = new List<CustomListTableData.CustomCellInfo>()
            {
                new CustomListTableData.CustomCellInfo(text: rO.Descriptor.Name, icon: rO.Descriptor.Icon),
                new CustomListTableData.CustomCellInfo(text: rW.Descriptor.Name, icon: rW.Descriptor.Icon),
                new CustomListTableData.CustomCellInfo(text: rC.Descriptor.Name, icon: rC.Descriptor.Icon),
                new CustomListTableData.CustomCellInfo(text: rP.Descriptor.Name, icon: rP.Descriptor.Icon),
                new CustomListTableData.CustomCellInfo(text: rD.Descriptor.Name, icon: rD.Descriptor.Icon)
            };
            foreach (CustomListTableData.CustomCellInfo cellInfo in cellInfos)
            {
                customListTableData.data.Add(cellInfo);
            }

            customListTableData.tableView.ReloadData();

            int selectedRainbow = (int)currentPreset;

            customListTableData.tableView.ScrollToCellWithIdx(selectedRainbow, TableViewScroller.ScrollPositionType.Beginning, false);
            customListTableData.tableView.SelectCellWithIdx(selectedRainbow);
        }

        protected override void DidActivate(bool firstActivation, ActivationType type)
        {
            base.DidActivate(firstActivation, type);
            Select(customListTableData.tableView, (int)currentPreset);
        }

        protected override void DidDeactivate(DeactivationType deactivationType)
        {
            base.DidDeactivate(deactivationType);
            PluginConfig.Instance.Preset = currentPreset.ToString();
        }

        public void ChangeDescription(int selected)
        {
            string[] rainbowNames = new string[] { rO.Descriptor.Name, rW.Descriptor.Name, rC.Descriptor.Name, rP.Descriptor.Name, rD.Descriptor.Name };
            string currentRainbowName = rainbowNames[selected];
            string[] rainbowDescriptions = new string[] { rO.Descriptor.Description, rW.Descriptor.Description, rC.Descriptor.Description, rP.Descriptor.Description, rD.Descriptor.Description };
            string currentRainbowDescription = rainbowDescriptions[selected];
            if (currentRainbowName != null && currentRainbowDescription != null)
            {
                rainbowChanged?.Invoke(currentRainbowName, currentRainbowDescription);
            }
        }
    }
}
