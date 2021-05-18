using System;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;

namespace Content.Server.AdminLog.LogEntries
{
    public abstract class PullingLogEntry: LogEntryWithUser
    {
        public readonly EntityUid Target;

        protected PullingLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()} Target={Target}";
        }
    }

    public class PullingStartLogEntry : PullingLogEntry
    {
        public PullingStartLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
        }
    }

    public class PullingStopLogEntry : PullingLogEntry
    {
        public PullingStopLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
        }
    }
}
