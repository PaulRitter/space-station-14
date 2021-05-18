using System;
using Robust.Shared.Map;

namespace Content.Server.AdminLog.LogEntries
{
    public abstract class LogEntry
    {
        public readonly DateTime Timestamp;
        public readonly EntityCoordinates EntityCoordinates;
        public readonly MapCoordinates MapCoordinates;

        protected LogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates)
        {
            Timestamp = timestamp;
            EntityCoordinates = entityCoordinates;
            MapCoordinates = mapCoordinates;
        }

        public override string ToString()
        {
            return $"[{Timestamp}] ({GetType()}) ({EntityCoordinates}) ({MapCoordinates})";
        }
    }

    public abstract class LogEntryWithUser : LogEntry
    {
        public readonly string Accountname;

        protected LogEntryWithUser(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, string accountname) : base(timestamp, entityCoordinates, mapCoordinates)
        {
            Accountname = accountname;
        }

        public override string ToString()
        {
            return $"{base.ToString()} User='{Accountname}'";
        }
    }
}
