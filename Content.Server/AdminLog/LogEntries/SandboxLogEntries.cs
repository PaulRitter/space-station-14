using System;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;

namespace Content.Server.AdminLog.LogEntries
{
    public class SandboxEntitySpawnLogEntry : LogEntryWithUser
    {
        public readonly EntityUid Entity;

        public SandboxEntitySpawnLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, EntityUid entity) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
            Entity = entity;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Entity={Entity}";
        }
    }

    public class SandboxGridCreationLogEntry : LogEntryWithUser
    {
        public readonly EntityUid Grid;

        public SandboxGridCreationLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, EntityUid grid) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
            Grid = grid;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Grid={Grid}";
        }
    }
}
