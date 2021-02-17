#nullable enable
using Robust.Shared.Localization;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.Utility;
using YamlDotNet.RepresentationModel;

namespace Content.Shared.Access
{
    /// <summary>
    ///     Defines a single access level that can be stored on ID cards and checked for.
    /// </summary>
    [Prototype("accessLevel")]
    public class AccessLevelPrototype : IPrototype, IIndexedPrototype
    {
        [YamlField("id")] public string ID { get; private set; } = "";

        /// <summary>
        ///     The player-visible name of the access level, in the ID card console and such.
        /// </summary>
        [YamlField("name")]
        public string Name
        {
            get => _name ?? ID;
            private set => _name = Loc.GetString(value);
        }

        private string? _name;
    }
}
