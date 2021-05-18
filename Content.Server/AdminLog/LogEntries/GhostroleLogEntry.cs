using System;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;

namespace Content.Server.AdminLog.LogEntries
{
    public abstract class GhostRoleLogEntry : LogEntryWithUser
    {
        public readonly string RoleName;
        public readonly EntityUid Entity;

        protected GhostRoleLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, string roleName, EntityUid entity) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
            RoleName = roleName;
            Entity = entity;
        }
    }

    public class GhostRoleCreationLogEntry : GhostRoleLogEntry
    {
        public GhostRoleCreationLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, [NotNull] string roleName, EntityUid entity) : base(timestamp, entityCoordinates, mapCoordinates, accountname, roleName, entity)
        {
        }
    }

    public class GhostRoleTakeoverEntry : GhostRoleLogEntry
    {
        public GhostRoleTakeoverEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, [NotNull] string roleName, EntityUid entity) : base(timestamp, entityCoordinates, mapCoordinates, accountname, roleName, entity)
        {
        }
    }
}
