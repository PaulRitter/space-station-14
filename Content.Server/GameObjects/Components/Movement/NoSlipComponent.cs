using Content.Shared.GameObjects;
using Content.Shared.GameObjects.EntitySystems;
using Robust.Shared.GameObjects;

namespace Content.Server.GameObjects.Components.Movement
{
    [RegisterComponent]
    [IgnoreOnClient]
    public class NoSlipComponent : Component, IEffectBlocker
    {
        public override string Name => "NoSlip";

        bool IEffectBlocker.CanSlip() => false;
    }
}
