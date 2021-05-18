using System;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;

namespace Content.Server.AdminLog.LogEntries
{
    public class EntityChangeLogEntry : LogEntryWithUser
    {
        public readonly EntityUid PreviousEntity;
        public readonly EntityUid NewEntity;
        public readonly bool Visit;

        public EntityChangeLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, EntityUid previousEntity, EntityUid newEntity, bool visit) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
            PreviousEntity = previousEntity;
            NewEntity = newEntity;
            Visit = visit;
        }
    }
}
