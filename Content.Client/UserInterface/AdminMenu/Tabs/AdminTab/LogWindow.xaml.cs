using System;
using Content.Shared.Administration.AdminMenu;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Network;

namespace Content.Client.UserInterface.AdminMenu.Tabs.AdminTab
{
    [GenerateTypedNameReferences]
    public partial class LogWindow : SS14Window
    {
        [Dependency] private INetManager _netManager = default!;

        public event Action<AdminMenuLogRequest>? LogsRequested;

        public LogWindow()
        {
            RobustXamlLoader.Load(this);

            AllButton.OnPressed += _ => LogsRequested?.Invoke(_netManager.CreateNetMessage<AdminMenuAllLogRequest>());
            PointSelectorButton.OnPressed += PointSelectorButtonOnPressed;
            AreaSelectorButton.OnPressed += AreaSelectorButtonOnPressed;
        }

        private void AreaSelectorButtonOnPressed(BaseButton.ButtonEventArgs obj)
        {
            throw new System.NotImplementedException();
        }

        private void PointSelectorButtonOnPressed(BaseButton.ButtonEventArgs obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
