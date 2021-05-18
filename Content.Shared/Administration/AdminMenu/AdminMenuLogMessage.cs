using Lidgren.Network;
using Robust.Shared.Network;

namespace Content.Shared.Administration.AdminMenu
{
    public class AdminMenuLogMessage : NetMessage
    {
        public static readonly MsgGroups GROUP = MsgGroups.Command;
        public static readonly string NAME = nameof(AdminMenuLogMessage);
        public AdminMenuLogMessage() : base(NAME, GROUP) { }

        //todo paul actually send logs

        public override void ReadFromBuffer(NetIncomingMessage buffer)
        {

        }

        public override void WriteToBuffer(NetOutgoingMessage buffer)
        {

        }
    }
}
