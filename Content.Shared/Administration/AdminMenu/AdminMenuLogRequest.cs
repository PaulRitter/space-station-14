using Lidgren.Network;
using Robust.Shared.Map;
using Robust.Shared.Network;

namespace Content.Shared.Administration.AdminMenu
{
    public abstract class AdminMenuLogRequest : NetMessage
    {
        protected AdminMenuLogRequest(string name, MsgGroups @group) : base(name, @group)
        {
        }
    }

    public class AdminMenuAllLogRequest : AdminMenuLogRequest
    {
        public static readonly MsgGroups GROUP = MsgGroups.Command;
        public static readonly string NAME = nameof(AdminMenuAllLogRequest);
        public AdminMenuAllLogRequest() : base(NAME, GROUP) { }
        public override void ReadFromBuffer(NetIncomingMessage buffer) { }

        public override void WriteToBuffer(NetOutgoingMessage buffer) { }
    }

    public class AdminMenuPointRequest : AdminMenuLogRequest
    {
        public static readonly MsgGroups GROUP = MsgGroups.Command;
        public static readonly string NAME = nameof(AdminMenuPointRequest);
        public AdminMenuPointRequest() : base(NAME, GROUP) { }

        public EntityCoordinates EntityCoordinates;

        public override void ReadFromBuffer(NetIncomingMessage buffer)
        {
            EntityCoordinates = buffer.ReadEntityCoordinates();
        }

        public override void WriteToBuffer(NetOutgoingMessage buffer)
        {
            buffer.Write(EntityCoordinates);
        }
    }

    public class AdminMenuAreaRequest : AdminMenuLogRequest
    {
        public static readonly MsgGroups GROUP = MsgGroups.Command;
        public static readonly string NAME = nameof(AdminMenuAreaRequest);
        public AdminMenuAreaRequest() : base(NAME, GROUP) { }

        public EntityCoordinates TopLeft;
        public EntityCoordinates BottomRight;
        public override void ReadFromBuffer(NetIncomingMessage buffer)
        {
            TopLeft = buffer.ReadEntityCoordinates();
            BottomRight = buffer.ReadEntityCoordinates();
        }

        public override void WriteToBuffer(NetOutgoingMessage buffer)
        {
            buffer.Write(TopLeft);
            buffer.Write(BottomRight);
        }
    }
}
