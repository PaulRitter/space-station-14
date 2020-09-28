using System.Linq;
using Content.Server.GameObjects.EntitySystems;
using Robust.Server.Interfaces.Console;
using Robust.Server.Interfaces.Player;
using Robust.Shared.GameObjects.Systems;
using Robust.Shared.Interfaces.Map;
using Robust.Shared.IoC;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Utility;

namespace Content.Server
{
    public class TempSalvageCommands : IClientCommand
    {
        public string Command => "salvagetest";
        public string Description => "salvagetest.";
        public string Help => $"{Command}";
        public void Execute(IConsoleShell shell, IPlayerSession? player, string[] args)
        {
            float[] distances = new float[8] {1,1,1,1,1,1,1,1};
            for (int i = 0; i < distances.Length && i < args.Length; i++)
            {
                if (int.TryParse(args[i], out var temp_dist))
                {
                    distances[i] = temp_dist;
                }
            }

            var shape = new SalvageCrewSystem.SalvageCrewObjectShape(distances[0], distances[1], distances[2],
                distances[3], distances[4], distances[5], distances[6], distances[7]);

            var min_x = shape.offsets.Min(v => v.X);
            var min_y = shape.offsets.Min(v => v.Y);
            var max_x = shape.offsets.Max(v => v.X);
            var max_y = shape.offsets.Max(v => v.Y);

            var entity = player.AttachedEntity;
            if (entity == null) return;

            var grid = IoCManager.Resolve<IMapManager>().CreateGrid(entity.Transform.MapID);
            grid.WorldPosition = entity.Transform.WorldPosition;

            foreach (var vec in shape.offsets)
            {
                grid.SetTile(new EntityCoordinates(grid.GridEntityId, vec), new Tile(IoCManager.Resolve<ITileDefinitionManager>()["floor_steel"].TileId));
            }

            /*var msg = "Grid:";
            for (int y = min_y; y <= max_y; y++)
            {
                msg += "\n";
                for (int x = min_x; x <= max_x; x++)
                {
                    msg += shape.offsets.FirstOrNull(v => v.X == x && v.Y == y) == null ? "=" : "X";
                }
            }

            shell.SendText(player, msg);*/
        }
    }
}
