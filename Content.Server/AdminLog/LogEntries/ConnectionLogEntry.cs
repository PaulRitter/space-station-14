using System;
using JetBrains.Annotations;
using Robust.Shared.Map;

namespace Content.Server.AdminLog.LogEntries
{
    public class ConnectionLogEntry : LogEntryWithUser
    {
        public ConnectionLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
        }
    }

    public class LeavingLogEntry : LogEntryWithUser
    {
        public LeavingLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
        }
    }
}
