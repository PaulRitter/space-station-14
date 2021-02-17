﻿using System;
using Content.Server.GameObjects.Components.Mobs;
using Content.Shared.Audio;
using Content.Shared.Damage;
using Content.Shared.GameObjects.Components.Damage;
using Robust.Server.GameObjects.EntitySystems;
using Robust.Shared.GameObjects;
using Robust.Shared.GameObjects.Components;
using Robust.Shared.GameObjects.Systems;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.Interfaces.Random;
using Robust.Shared.Interfaces.Timing;
using Robust.Shared.IoC;
using Robust.Shared.Prototypes;
using Robust.Shared.Random;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.Manager.Attributes;

namespace Content.Server.GameObjects.Components.Damage
{
    [RegisterComponent]
    public class DamageOnHighSpeedImpactComponent : Component, ICollideBehavior
    {
        [Dependency] private readonly IRobustRandom _robustRandom = default!;
        [Dependency] private readonly IGameTiming _gameTiming = default!;

        public override string Name => "DamageOnHighSpeedImpact";

        [YamlField("damage")]
        public DamageType Damage { get; set; } = DamageType.Blunt;
        [YamlField("minimumSpeed")]
        public float MinimumSpeed { get; set; } = 20f;
        [YamlField("baseDamage")]
        public int BaseDamage { get; set; } = 5;
        [YamlField("factor")]
        public float Factor { get; set; } = 1f;
        [YamlField("soundHit")]
        public string SoundHit { get; set; } = "";
        [YamlField("stunChance")]
        public float StunChance { get; set; } = 0.25f;
        [YamlField("stunMinimumDamage")]
        public int StunMinimumDamage { get; set; } = 10;
        [YamlField("stunSeconds")]
        public float StunSeconds { get; set; } = 1f;
        [YamlField("damageCooldown")]
        public float DamageCooldown { get; set; } = 2f;
        private TimeSpan _lastHit = TimeSpan.Zero;

        public void CollideWith(IEntity collidedWith)
        {
            if (!Owner.TryGetComponent(out IPhysicsComponent physics) || !Owner.TryGetComponent(out IDamageableComponent damageable)) return;

            var speed = physics.LinearVelocity.Length;

            if (speed < MinimumSpeed) return;

            if(!string.IsNullOrEmpty(SoundHit))
                EntitySystem.Get<AudioSystem>().PlayFromEntity(SoundHit, collidedWith, AudioHelpers.WithVariation(0.125f).WithVolume(-0.125f));

            if ((_gameTiming.CurTime - _lastHit).TotalSeconds < DamageCooldown)
                return;

            _lastHit = _gameTiming.CurTime;

            var damage = (int) (BaseDamage * (speed / MinimumSpeed) * Factor);

            if (Owner.TryGetComponent(out StunnableComponent stun) && _robustRandom.Prob(StunChance))
                stun.Stun(StunSeconds);

            damageable.ChangeDamage(Damage, damage, false, collidedWith);
        }
    }
}
