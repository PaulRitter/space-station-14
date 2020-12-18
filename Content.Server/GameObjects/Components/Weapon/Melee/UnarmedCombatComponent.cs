using Content.Shared.GameObjects;
using Robust.Shared.GameObjects;

namespace Content.Server.GameObjects.Components.Weapon.Melee
{
    [RegisterComponent]
    [IgnoreOnClient]
    public class UnarmedCombatComponent : MeleeWeaponComponent
    {
        public override string Name => "UnarmedCombat";
    }
}
