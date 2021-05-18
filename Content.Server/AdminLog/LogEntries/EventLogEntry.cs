using System;
using JetBrains.Annotations;
using Robust.Shared.Map;
using Robust.Shared.Timing;

namespace Content.Server.AdminLog.LogEntries
{
    public abstract class EventLogEntry : LogEntry
    {
        public readonly string? Admin;
        public readonly GameTick Time;
        public readonly Type EventType;

        protected EventLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, string? admin, GameTick time, Type eventType) : base(timestamp, entityCoordinates, mapCoordinates)
        {
            Admin = admin;
            Time = time;
            EventType = eventType;
        }
    }

    public class EventStartLogEntry : EventLogEntry
    {
        public EventStartLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [CanBeNull] string? admin, GameTick time, [NotNull] Type eventType) : base(timestamp, entityCoordinates, mapCoordinates, admin, time, eventType)
        {
        }
    }

    public class EventEndLogEntry : EventLogEntry
    {
        public EventEndLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [CanBeNull] string? admin, GameTick time, [NotNull] Type eventType) : base(timestamp, entityCoordinates, mapCoordinates, admin, time, eventType)
        {
        }
    }
}
