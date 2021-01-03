﻿using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Shared.GameObjects.Components.Body.Part.Property
{
    /// <summary>
    ///     Property attachable to a <see cref="IBodyPart"/>.
    ///     For example, this is used to define the speed capabilities of a leg.
    ///     The movement system will look for a <see cref="LegComponent"/> on all
    ///     <see cref="IBodyPart"/>.
    /// </summary>
    public abstract class BodyPartPropertyComponent : Component, IBodyPartProperty
    {
        /// <summary>
        ///     Whether this property is currently active.
        /// </summary>
        [YamlField("active")]
        public bool Active { get; set; } = true;
    }
}
