using Content.Shared.GameObjects;
using Robust.Shared.GameObjects;

namespace Content.Server.GameObjects.Components.Portal
{
    [RegisterComponent]
    [IgnoreOnClient]
    public class TeleportableComponent : Component
    {
        public override string Name => "Teleportable";
    }
}
