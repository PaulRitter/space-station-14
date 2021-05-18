using System;
using System.Collections.Generic;
using System.Linq;
using Content.Server.AdminLog.LogEntries;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;

namespace Content.Server.AdminLog
{
    public interface IAdminLogManager
    {
        IEntityManager _entityManager { get; set; }

        void Log<T>(T entry) where T : LogEntry;

        LogEntry[] GetEntries(Func<LogEntry, bool>? predicate = null);

        LogEntry[] GetEntries(string username, bool ignoreUnspecified = true) =>
            GetEntries(x => x is LogEntryWithUser withUser && withUser.Accountname == username || x is not LogEntryWithUser && !ignoreUnspecified);

        LogEntry[] GetEntries(EntityCoordinates entityCoordinates, float distance = 1f) => GetEntries(x =>
            x.EntityCoordinates.TryDistance(_entityManager, entityCoordinates, out var dist) && dist <= distance);

        LogEntry[] GetEntries(EntityCoordinates topLeft, EntityCoordinates bottomRight) => GetEntries(x =>
            new Box2(topLeft.ToMapPos(_entityManager), bottomRight.ToMapPos(_entityManager)).Contains(
                x.EntityCoordinates.ToMapPos(_entityManager))
        );
    }

    public class AdminLogManager : IAdminLogManager
    {
        [field: Dependency] public IEntityManager _entityManager { get; set; } = default!;

        private List<LogEntry> _logEntries = new();

        public void Log<T>(T entry) where T : LogEntry
        {
            _logEntries.Add(entry);
            //todo send to db
        }

        public LogEntry[] GetEntries(Func<LogEntry, bool>? predicate = null)
        {
            return predicate != null ? _logEntries.Where(predicate).ToArray() : _logEntries.ToArray();
        }
    }
}
