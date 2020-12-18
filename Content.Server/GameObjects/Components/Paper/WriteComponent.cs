using Content.Shared.GameObjects;
using Robust.Shared.GameObjects;

namespace Content.Server.GameObjects.Components.Paper
{
    [RegisterComponent]
    [IgnoreOnClient]
    public class WriteComponent : Component
    {
        public override string Name => "Write";
    }
}
