using Content.Shared.GameObjects;
using Robust.Shared.GameObjects;

namespace Content.Server.GameObjects.Components.Damage
{
    [RegisterComponent]
    [IgnoreOnClient]
    public class BreakableComponent : Component
    {
        public override string Name => "Breakable";
    }
}
