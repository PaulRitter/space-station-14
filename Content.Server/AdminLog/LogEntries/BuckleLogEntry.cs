using System;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;

namespace Content.Server.AdminLog.LogEntries
{
    public abstract class BaseBuckleLogEntry : LogEntryWithUser
    {
        /// <summary>
        /// Who is buckling.
        /// </summary>
        public readonly EntityUid Buckler;
        /// <summary>
        /// Who is being buckled.
        /// </summary>
        public readonly EntityUid Bucklee;
        /// <summary>
        /// What are they being buckled to.
        /// </summary>
        public readonly EntityUid Target;

        public BaseBuckleLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, EntityUid buckler, EntityUid bucklee, EntityUid target) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
            Buckler = buckler;
            Bucklee = bucklee;
            Target = target;
        }
    }

    public class BuckleAttemptLogEntry : BaseBuckleLogEntry
    {
        public BuckleAttemptLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, EntityUid buckler, EntityUid bucklee, EntityUid target) : base(timestamp, entityCoordinates, mapCoordinates, accountname, buckler, bucklee, target)
        {
        }
    }

    public class BuckleLogEntry : BaseBuckleLogEntry
    {
        public BuckleLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, EntityUid buckler, EntityUid bucklee, EntityUid target) : base(timestamp, entityCoordinates, mapCoordinates, accountname, buckler, bucklee, target)
        {
        }
    }
}
