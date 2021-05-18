using System;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;

namespace Content.Server.AdminLog.LogEntries
{
    public class InteractionLogEntry : LogEntryWithUser
    {
        public readonly EntityUid Target;
        public readonly InteractionType Type;
        public readonly EntityUid? Item;
        //todo damage dealt?

        public enum InteractionType
        {
            Interact,
            Attack
        }

        public InteractionLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, EntityUid target, InteractionType type, EntityUid? item) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
            Target = target;
            Type = type;
            Item = item;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Target={Target} Type={Type} Item={(Item != null ? Item.ToString() : "None")}";
        }
    }
}
