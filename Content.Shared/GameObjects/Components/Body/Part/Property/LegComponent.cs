﻿using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.Manager.Attributes;

namespace Content.Shared.GameObjects.Components.Body.Part.Property
{
    /// <summary>
    ///     Defines the speed at which a <see cref="IBodyPart"/> can move.
    /// </summary>
    [RegisterComponent]
    public class LegComponent : BodyPartPropertyComponent
    {
        public override string Name => "Leg";

        /// <summary>
        ///     Speed in tiles per second.
        /// </summary>
        [YamlField("speed")]
        public float Speed { get; set; } = 2.6f;
    }
}
