using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.Manager.Attributes;

namespace Content.Server.GameObjects.Components.Mining
{
    [RegisterComponent]
    public class PickaxeComponent : Component

    {
        public override string Name => "Pickaxe";
        [YamlField("miningSound")]
        public string MiningSound = "/Audio/Items/Mining/pickaxe.ogg";
        [YamlField("miningSpeedMultiplier")]
        public float MiningSpeedMultiplier = 1f;
    }
}
