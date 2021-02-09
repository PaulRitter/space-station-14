#nullable enable
using System;
using Content.Shared.Construction;
using Content.Shared.Roles;
using Robust.Client.AutoGenerated;
using Robust.Client.Console;
using Robust.Client.Interfaces.ResourceManagement;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;
using Robust.Client.Utility;
using Robust.Shared.GameObjects;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Localization;
using Robust.Shared.Maths;
using Robust.Shared.Prototypes;

namespace Content.Client.UserInterface.AdminMenu.SetOutfit
{
    [GenerateTypedNameReferences]
    public partial class SetOutfitMenu : SS14Window
    {
        [Dependency] private readonly IPrototypeManager _prototypeManager = default!;
        [Dependency] private readonly IClientConsoleHost _consoleHost = default!;

        public EntityUid? TargetEntityId { get; set; }
        protected override Vector2? CustomSize => (250, 320);

        private StartingGearPrototype? _selectedOutfit;

        public SetOutfitMenu()
        {
            IoCManager.InjectDependencies(this);
            RobustXamlLoader.Load(this);

            Title = Loc.GetString("Set Outfit");

            ConfirmButton.Text = Loc.GetString("Confirm");
            ConfirmButton.OnPressed += ConfirmButtonOnOnPressed;
            SearchBar.OnTextChanged += SearchBarOnOnTextChanged;
            OutfitList.OnItemSelected += OutfitListOnOnItemSelected;
            OutfitList.OnItemDeselected += OutfitListOnOnItemDeselected;
            PopulateList();
        }

        private void ConfirmButtonOnOnPressed(BaseButton.ButtonEventArgs obj)
        {
            if (TargetEntityId == null || _selectedOutfit == null)
                return;
            var command = $"setoutfit {TargetEntityId} {_selectedOutfit.ID}";
            _consoleHost.ExecuteCommand(command);
            Close();
        }

        private void OutfitListOnOnItemSelected(ItemList.ItemListSelectedEventArgs obj)
        {
            _selectedOutfit = (StartingGearPrototype) obj.ItemList[obj.ItemIndex].Metadata!;
            ConfirmButton.Disabled = false;
        }

        private void OutfitListOnOnItemDeselected(ItemList.ItemListDeselectedEventArgs obj)
        {
            _selectedOutfit = null;
            ConfirmButton.Disabled = true;
        }


        private void SearchBarOnOnTextChanged(LineEdit.LineEditEventArgs obj)
        {
            PopulateByFilter(SearchBar.Text);
        }

        private void PopulateList()
        {
            foreach (var gear in _prototypeManager.EnumeratePrototypes<StartingGearPrototype>())
            {
                OutfitList.Add(GetItem(gear, OutfitList));
            }
        }

        private void PopulateByFilter(string filter)
        {
            OutfitList.Clear();
            foreach (var gear in _prototypeManager.EnumeratePrototypes<StartingGearPrototype>())
            {
                if (!string.IsNullOrEmpty(filter) &&
                    gear.ID.ToLowerInvariant().Contains(filter.Trim().ToLowerInvariant()))
                {
                    OutfitList.Add(GetItem(gear, OutfitList));
                }
            }
        }


        private static ItemList.Item GetItem(StartingGearPrototype gear, ItemList itemList)
        {
            return new(itemList)
            {
                Metadata = gear,
                Text = gear.ID
            };
        }
    }
}