using System;
using JetBrains.Annotations;
using Robust.Shared.Map;

namespace Content.Server.AdminLog.LogEntries
{
    public class MovementLogEntry : LogEntryWithUser
    {
        public MovementLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
        }
    }
}
