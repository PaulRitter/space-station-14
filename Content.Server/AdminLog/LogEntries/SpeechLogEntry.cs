using System;
using Content.Shared.Chat;
using JetBrains.Annotations;
using Robust.Shared.Map;

namespace Content.Server.AdminLog.LogEntries
{
    public class SpeechLogEntry : LogEntryWithUser
    {
        public readonly string Message;
        public readonly ChatChannel Channel;
        //TODO ACCENT?

        public SpeechLogEntry(DateTime timestamp, EntityCoordinates entityCoordinates, MapCoordinates mapCoordinates, [NotNull] string accountname, string message, ChatChannel channel) : base(timestamp, entityCoordinates, mapCoordinates, accountname)
        {
            Message = message;
            Channel = channel;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Channel={Channel} Message={Message}";
        }
    }
}
