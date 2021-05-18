using System;
using JetBrains.Annotations;
using Robust.Shared.Map;

namespace Content.Server.AdminLog.LogEntries
{
    public class EmoteLogEntry : LogEntryWithUser
    {
        public readonly string Emote;

        public EmoteLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, string emote) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
            Emote = emote;
        }
    }
}
