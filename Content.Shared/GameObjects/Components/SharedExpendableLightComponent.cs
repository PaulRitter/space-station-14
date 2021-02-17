﻿using System;
using Robust.Shared.GameObjects;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.ViewVariables;

namespace Content.Shared.GameObjects.Components
{
    [Serializable, NetSerializable]
    public enum ExpendableLightVisuals
    {
        State
    }

    [Serializable, NetSerializable]
    public enum ExpendableLightState
    {
        BrandNew,
        Lit,
        Fading,
        Dead
    }

    public abstract class SharedExpendableLightComponent: Component
    {
        public sealed override string Name => "ExpendableLight";

        [ViewVariables(VVAccess.ReadOnly)]
        protected ExpendableLightState CurrentState { get; set; }

        [ViewVariables]
        [YamlField("turnOnBehaviourID")]
        protected string TurnOnBehaviourID { get; set; } = string.Empty;

        [ViewVariables]
        [YamlField("fadeOutBehaviourID")]
        protected string FadeOutBehaviourID { get; set; } = string.Empty;

        [ViewVariables]
        [YamlField("glowDuration")]
        protected float GlowDuration { get; set; } = 60 * 15f;

        [ViewVariables]
        [YamlField("fadeOutDuration")]
        protected float FadeOutDuration { get; set; } = 60 * 5f;

        [ViewVariables]
        [YamlField("spentDesc")]
        protected string SpentDesc { get; set; } = string.Empty;

        [ViewVariables]
        [YamlField("spentName")]
        protected string SpentName { get; set; } = string.Empty;

        [ViewVariables]
        [YamlField("iconStateSpent")]
        protected string IconStateSpent { get; set; } = string.Empty;

        [ViewVariables]
        [YamlField("iconStateOn")]
        protected string IconStateLit { get; set; } = string.Empty;

        [ViewVariables]
        [YamlField("litSound")]
        protected string LitSound { get; set; } = string.Empty;

        [ViewVariables]
        [YamlField("loopedSound")]
        protected string LoopedSound { get; set; } = string.Empty;

        [ViewVariables]
        [YamlField("dieSound")]
        protected string DieSound { get; set; } = string.Empty;
    }
}
