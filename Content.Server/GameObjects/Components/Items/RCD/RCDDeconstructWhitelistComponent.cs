using Content.Shared.GameObjects;
using Robust.Shared.GameObjects;

namespace Content.Server.GameObjects.Components.Items.RCD
{
    [RegisterComponent]
    [IgnoreOnClient]
    public class RCDDeconstructWhitelist : Component
    {
        public override string Name => "RCDDeconstructWhitelist";
    }
}
